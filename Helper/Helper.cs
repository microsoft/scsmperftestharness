using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Packaging;
using Microsoft.EnterpriseManagement.Configuration.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Microsoft.EnterpriseManagement.Helper
{
    public class Helper
    {
        public static ManagementPackClass GetClassByName(string strName, EnterpriseManagementGroup emg)
        {
            ManagementPackClassCriteria mpcc = new ManagementPackClassCriteria(String.Format("Name = '{0}'", strName));
            IList<ManagementPackClass> listClasses = emg.EntityTypes.GetClasses(mpcc);
            if (listClasses.Count > 0)
            {
                return (listClasses[0]);
            }
            else
            {
                return null;
            }
        }

        public static ManagementPackTypeProjection GetTypeProjectionByName(string strName, EnterpriseManagementGroup emg)
        {
            ManagementPackTypeProjectionCriteria mptpc = new ManagementPackTypeProjectionCriteria(String.Format("Name = '{0}'", strName));
            IList<ManagementPackTypeProjection> listTypeProjections = emg.EntityTypes.GetTypeProjections(mptpc);
            if (listTypeProjections.Count > 0)
            {
                return (listTypeProjections[0]);
            }
            else
            {
                return null;
            }
        }

        public static ManagementPackRelationship GetRelationshipByName(string strName, EnterpriseManagementGroup emg)
        {
            ManagementPackRelationshipCriteria mprc = new ManagementPackRelationshipCriteria(String.Format("Name = '{0}'", strName));
            IList<ManagementPackRelationship> listRelationships = emg.EntityTypes.GetRelationshipClasses(mprc);
            if (listRelationships.Count > 0)
            {
                return (listRelationships[0]);
            }
            else
            {
                return null;
            }
        }

        public static ManagementPackEnumeration GetEnumerationByName(string strName, EnterpriseManagementGroup emg)
        {
            ManagementPackEnumerationCriteria mpec = new ManagementPackEnumerationCriteria(String.Format("Name = '{0}'", strName));
            IList<ManagementPackEnumeration> listEnumerations = emg.EntityTypes.GetEnumerations(mpec);
            if (listEnumerations.Count > 0)
            {
                return (listEnumerations[0]);
            }
            else
            {
                return null;
            }
        }

        public static ManagementPack GetManagementPackByName(string strName, EnterpriseManagementGroup emg)
        {
            ManagementPackCriteria mpc = new ManagementPackCriteria(String.Format("Name = '{0}'", strName));
            IList<ManagementPack> listManagementPacks = emg.ManagementPacks.GetManagementPacks(mpc);
            if (listManagementPacks.Count > 0)
            {
                return (listManagementPacks[0]);
            }
            else
            {
                return null;
            }
        }

        public static ManagementPackProperty GetManagementPackClassPropertyByName(string strClassName, string strPropertyName, EnterpriseManagementGroup emg)
        {
            ManagementPackClass cls = GetClassByName(strClassName, emg);
            IList<ManagementPackProperty> listProperties = cls.GetProperties();
            foreach (ManagementPackProperty property in listProperties)
            {
                if (property.Name == strPropertyName)
                    return (property);
            }

            return null;
        }

        public static ManagementPackObjectTemplate GetObjectTemplateByName(string strObjectTemplateName, EnterpriseManagementGroup emg)
        {
            ManagementPackObjectTemplateCriteria mpotc = new ManagementPackObjectTemplateCriteria(String.Format("Name = '{0}'", strObjectTemplateName));
            IList<ManagementPackObjectTemplate> listManagementPackObjectTemplates = emg.Templates.GetObjectTemplates(mpotc);
            if (listManagementPackObjectTemplates.Count > 0)
            {
                return (listManagementPackObjectTemplates[0]);
            }
            else
            {
                return null;
            }

        }

        public static ManagementPack CreateNewManagementPackInMemory(string strName, string strVersion, string strInternalName, string strDisplayName, EnterpriseManagementGroup emg, Boolean bAddSMCategory)
        {
            StringReader sr = new StringReader(String.Format("<ManagementPack xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\" ContentReadable=\"true\" SchemaVersion=\"2.0\" OriginalSchemaVersion=\"1.1\">"
                                                                + "<Manifest>"
                                                                    + "<Identity>"
                                                                        + "<ID>{0}</ID>"
                                                                        + "<Version>{1}</Version>"
                                                                     + "</Identity>"
                                                                     + "<Name>{2}</Name>"
                                                                     + "<References/>"
                                                                + "</Manifest>"
                                                                + "<LanguagePacks>"
                                                                    + "<LanguagePack ID=\"ENU\" IsDefault=\"true\">"
                                                                        + "<DisplayStrings>"
                                                                            + "<DisplayString ElementID=\"{0}\">"
                                                                                + "<Name>{3}</Name>"
                                                                            + "</DisplayString>"
                                                                        + "</DisplayStrings>"
                                                                    + "</LanguagePack>"
                                                                + "</LanguagePacks>"
                                                            + "</ManagementPack>",
                                                            strName,
                                                            strVersion,
                                                            strInternalName,
                                                            strDisplayName));

            ManagementPack mp = new ManagementPack(sr, emg);
            if (bAddSMCategory)
            {
                ManagementPackEnumeration mpeSMMP = GetEnumerationByName("Microsoft.EnterpriseManagement.ServiceManager.ManagementPack", emg);
                ManagementPackCategory mpcatSMMP = new ManagementPackCategory(mp, String.Format("Category.{0}", MakeMPElementSafeName(Guid.NewGuid().ToString())));
                mpcatSMMP.Value = mpeSMMP;
                mpcatSMMP.ManagementPackName = strName;
                mpcatSMMP.ManagementPackVersion = strVersion;
                mpcatSMMP.Status = ManagementPackElementStatus.PendingAdd;
                mp.AcceptChanges();
            }
            return mp;
        }

        public static void AddManagementPackReference(string strAlias, string strMPName, ref ManagementPack mp, EnterpriseManagementGroup emg)
        {
            ManagementPack mpReference = GetManagementPackByName(strMPName, emg);
            ManagementPackReference mpr = new ManagementPackReference(mpReference);
            foreach (KeyValuePair<string,ManagementPackReference> mprExisting in mp.References)
            {
                if (mprExisting.Value.Name == strMPName)
                    return;
            }
            mp.References.Add(strAlias, mpr);
            return;
        }

        public static void CreateQueue(string strDisplayName, string strName, string strCriteria, ManagementPackClass mpc, ref ManagementPack mp, EnterpriseManagementGroup emg)
        {
            ManagementPack mpClass = mpc.GetManagementPack();
            string strMPAlias = MakeMPElementSafeName(mpClass.Name);
            AddManagementPackReference(strMPAlias, mpClass.Name, ref mp, emg);

            ManagementPackClass classWorkItemGroup = GetClassByName("System.WorkItemGroup", emg);
            ManagementPackClass mpcQueue = new ManagementPackClass(mp, strName, ManagementPackAccessibility.Public);
            mpcQueue.Abstract = false;
            mpcQueue.Base = classWorkItemGroup;
            mpcQueue.DisplayName = strDisplayName;
            mpcQueue.Hosted = false;
            mpcQueue.Extension = false;
            mpcQueue.Singleton = true;
            mpcQueue.Status = ManagementPackElementStatus.PendingAdd;

            ManagementPackRelationship mprWorkItemGroupContainsWorkItem = GetRelationshipByName("System.WorkItemGroupContainsWorkItems", emg);
            ManagementPackRelationshipEndpoint mpreSource = new ManagementPackRelationshipEndpoint(mpcQueue, "ContainedByGroup");
            ManagementPackRelationshipEndpoint mpreTarget = new ManagementPackRelationshipEndpoint(mpcQueue, "GroupContains");
            mpreSource.Type = mpcQueue;
            mpreTarget.Type = mp.ProcessElementReference<ManagementPackClass>(String.Format("$MPElement[Name=\"{0}!{1}\"]$", strMPAlias, mpc.Name));
            
            ManagementPackRelationship mprQueueWorkItem = new ManagementPackRelationship(mp, String.Format("{0}.Relationship", strName), ManagementPackAccessibility.Public);
            mprQueueWorkItem.DisplayName = String.Format("{0} Contains {1}", strDisplayName, mpc.DisplayName);
            mprQueueWorkItem.Abstract = false;
            mprQueueWorkItem.Base = mprWorkItemGroupContainsWorkItem;
            mprQueueWorkItem.Source = mpreSource;
            mprQueueWorkItem.Target = mpreTarget;
            mprQueueWorkItem.Status = ManagementPackElementStatus.PendingAdd;

            ManagementPackDiscoveryRelationship mpdrQueueWorkItem = new ManagementPackDiscoveryRelationship();
            mpdrQueueWorkItem.TypeID = mprQueueWorkItem;

            ManagementPack mpSystemCenter = GetManagementPackByName("Microsoft.SystemCenter.Library", emg);
            string strSystemCenterLibraryMPAlias = MakeMPElementSafeName(mpSystemCenter.Name);
            AddManagementPackReference(strSystemCenterLibraryMPAlias, mpSystemCenter.Name, ref mp, emg);

            ManagementPackModuleType mpmtGroupPopulator = emg.Monitoring.GetModuleType("Microsoft.SystemCenter.GroupPopulator", mpSystemCenter);

            ManagementPackDiscovery mpdQueueWorkItem = new ManagementPackDiscovery(mp, MakeMPElementSafeName(String.Format("WorkITemGroup.{0}.Discovery.{1}", mpcQueue.Name, Guid.NewGuid().ToString())));

            ManagementPackDataSourceModule mpdsmPopulator = new ManagementPackDataSourceModule(mpdQueueWorkItem, MakeMPElementSafeName(Guid.NewGuid().ToString()));
            ManagementPackElementReference<ManagementPackDataSourceModuleType> mperGroupPopulator = mp.ProcessElementReference<ManagementPackDataSourceModuleType>(String.Format("$MPElement[Name=\"{0}!{1}\"]$", strSystemCenterLibraryMPAlias, mpmtGroupPopulator.Name));
            
            mpdsmPopulator.TypeID = mperGroupPopulator;
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<RuleId>$MPElement$</RuleId>\r\n");
            sb.Append(String.Format("<GroupInstanceId>$MPElement[Name=\"{0}\"]$</GroupInstanceId>\r\n", strName));
            sb.Append("<MembershipRules>\r\n");
            sb.Append("<MembershipRule>\r\n");
            sb.Append(String.Format("<MonitoringClass>$MPElement[Name=\"{0}!{1}\"]$</MonitoringClass>\r\n", strMPAlias, mpc.Name));
            sb.Append(String.Format("<RelationshipClass>$MPElement[Name=\"{0}\"]$</RelationshipClass>\r\n", mprQueueWorkItem.Name));
            sb.Append(strCriteria);
            sb.Append("</MembershipRule>\r\n");
            sb.Append("</MembershipRules>\r\n");

            mpdsmPopulator.Configuration = sb.ToString();
            
            mpdQueueWorkItem.Enabled = ManagementPackMonitoringLevel.@true;
            mpdQueueWorkItem.Target = mpcQueue;
            mpdQueueWorkItem.ConfirmDelivery = false;
            mpdQueueWorkItem.Remotable = true;
            mpdQueueWorkItem.Priority = ManagementPackWorkflowPriority.Normal;
            mpdQueueWorkItem.Category = ManagementPackCategoryType.Discovery;
            mpdQueueWorkItem.DiscoveryRelationshipCollection.Add(mpdrQueueWorkItem);
            mpdQueueWorkItem.DataSource = mpdsmPopulator;
            
            mp.AcceptChanges();
        }

        public static void CreateNotificationRule(string strDisplayName, string strName, string strCriteria, EnterpriseManagementObject emoUser, ManagementPackClass mpc, ManagementPackObjectTemplate mpt, ref ManagementPack mp, EnterpriseManagementGroup emg)
        {
            ManagementPack mpSystemCenterLibrary = Helper.GetManagementPackByName("Microsoft.SystemCenter.Library", emg);
            ManagementPack mpSubscriptions = Helper.GetManagementPackByName("Microsoft.SystemCenter.Subscriptions", emg);
            string strSubscriptionsMPAlias = MakeMPElementSafeName(mpSubscriptions.Name);
            AddManagementPackReference(strSubscriptionsMPAlias, mpSubscriptions.Name, ref mp, emg);
            string strSystemCenterLibraryMPAlias = MakeMPElementSafeName(mpSystemCenterLibrary.Name);
            AddManagementPackReference(strSystemCenterLibraryMPAlias, mpSystemCenterLibrary.Name, ref mp, emg);
            ManagementPackClass mpcSubscriptionWorkflowTarget = GetClassByName("Microsoft.SystemCenter.SubscriptionWorkflowTarget", emg);
            ManagementPackDataSourceModuleType mpdsmtSubscription = (ManagementPackDataSourceModuleType)mpSubscriptions.GetModuleType("Microsoft.SystemCenter.CmdbInstanceSubscription.DataSourceModule");
            
            ManagementPackRule mpr = new ManagementPackRule(mp, MakeMPElementSafeName(String.Format("NotificationSubscription.{0}", Guid.NewGuid())));
            mpr.Enabled = ManagementPackMonitoringLevel.@true;
            mpr.ConfirmDelivery = true;
            mpr.Remotable = true;
            mpr.Priority = ManagementPackWorkflowPriority.Normal;
            mpr.Category = ManagementPackCategoryType.System;
            mpr.DiscardLevel = 100;
            mpr.Target = mp.ProcessElementReference<ManagementPackClass>(String.Format("$MPElement[Name=\"{0}!{1}\"]$", strSystemCenterLibraryMPAlias, mpcSubscriptionWorkflowTarget.Name));

            ManagementPackDataSourceModule mpdsmSubscription = new ManagementPackDataSourceModule(mpr, "DS");
            mpdsmSubscription.TypeID = mp.ProcessElementReference<ManagementPackDataSourceModuleType>(String.Format("$MPElement[Name=\"{0}!{1}\"]$", strSubscriptionsMPAlias, mpdsmtSubscription.Name));

            StringBuilder sbDataSourceConfiguration = new StringBuilder();
            sbDataSourceConfiguration.Append("<Subscription>");
            sbDataSourceConfiguration.Append(String.Format("<InstanceSubscription Type=\"{0}\">", mpc.Id.ToString()));
            sbDataSourceConfiguration.Append(strCriteria);
            sbDataSourceConfiguration.Append("</InstanceSubscription>");
            sbDataSourceConfiguration.Append("<PollingIntervalInSeconds>60</PollingIntervalInSeconds>");
            sbDataSourceConfiguration.Append("<BatchSize>100</BatchSize>");
            sbDataSourceConfiguration.Append("</Subscription>");

            mpdsmSubscription.Configuration = sbDataSourceConfiguration.ToString();

            ManagementPackWriteActionModuleType mpwamtSubscription = (ManagementPackWriteActionModuleType)mpSubscriptions.GetModuleType("Microsoft.EnterpriseManagement.SystemCenter.Subscription.WindowsWorkflowTaskWriteAction");

            ManagementPackWriteActionModule mpwamSubscription = new ManagementPackWriteActionModule(mpr, "WA");
            mpwamSubscription.TypeID = mp.ProcessElementReference<ManagementPackWriteActionModuleType>(String.Format("$MPElement[Name=\"{0}!{1}\"]$", strSubscriptionsMPAlias, mpwamtSubscription.Name));

            StringBuilder sbWriteActionConfiguration = new StringBuilder();
            sbWriteActionConfiguration.Append("<Subscription>");
            sbWriteActionConfiguration.Append("<VisibleWorkflowStatusUi>true</VisibleWorkflowStatusUi>");
            sbWriteActionConfiguration.Append("<EnableBatchProcessing>true</EnableBatchProcessing>");
            sbWriteActionConfiguration.Append("<WindowsWorkflowConfiguration>");
            sbWriteActionConfiguration.Append("<AssemblyName>Microsoft.EnterpriseManagement.Notifications.Workflows</AssemblyName>");
            sbWriteActionConfiguration.Append("<WorkflowTypeName>Microsoft.EnterpriseManagement.Notifications.Workflows.SendNotificationsActivity</WorkflowTypeName>");
            sbWriteActionConfiguration.Append("<WorkflowParameters>");
            sbWriteActionConfiguration.Append("<WorkflowParameter Name=\"SubscriptionId\" Type=\"guid\">$MPElement$</WorkflowParameter>");
            sbWriteActionConfiguration.Append("<WorkflowArrayParameter Name=\"DataItems\" Type=\"string\">");
            sbWriteActionConfiguration.Append("<Item>$Data/.$</Item>");
            sbWriteActionConfiguration.Append("</WorkflowArrayParameter>");
            sbWriteActionConfiguration.Append("<WorkflowArrayParameter Name=\"InstanceIds\" Type=\"string\">");
            sbWriteActionConfiguration.Append("<Item>$Data/BaseManagedEntityId$</Item>");
            sbWriteActionConfiguration.Append("</WorkflowArrayParameter>");
            sbWriteActionConfiguration.Append("<WorkflowArrayParameter Name=\"TemplateIds\" Type=\"string\">");
            sbWriteActionConfiguration.Append(String.Format("<Item>{0}</Item>", mpt.Id.ToString()));
            sbWriteActionConfiguration.Append("</WorkflowArrayParameter>");
            sbWriteActionConfiguration.Append("<WorkflowArrayParameter Name=\"PrimaryUserList\" Type=\"string\">");
            sbWriteActionConfiguration.Append(String.Format("<Item>{0}</Item>", emoUser.Id.ToString()));
            sbWriteActionConfiguration.Append("</WorkflowArrayParameter>");
            sbWriteActionConfiguration.Append("</WorkflowParameters>");
            sbWriteActionConfiguration.Append("<RetryExceptions/>");
            sbWriteActionConfiguration.Append("<RetryDelaySeconds>60</RetryDelaySeconds>");
            sbWriteActionConfiguration.Append("<MaximumRunningTimeSeconds>7200</MaximumRunningTimeSeconds>");
            sbWriteActionConfiguration.Append("</WindowsWorkflowConfiguration>");
            sbWriteActionConfiguration.Append("</Subscription>");
            
            mpwamSubscription.Configuration = sbWriteActionConfiguration.ToString();

            mpr.DataSourceCollection.Add(mpdsmSubscription);
            mpr.WriteActionCollection.Add(mpwamSubscription);

            mpr.Status = ManagementPackElementStatus.PendingAdd;

            mp.AcceptChanges();

        }

        public static EnterpriseManagementObject GetUserFromEmailAddress(string strEmailAddress, EnterpriseManagementGroup emg)
        {
            strEmailAddress = MakeSafeXML(strEmailAddress);

            ManagementPack mpSystemNotificationsLibrary = GetManagementPackByName("System.Notifications.Library", emg);
            ManagementPack mpSystemSupportingItemLibrary = GetManagementPackByName("System.SupportingItem.Library", emg);

            if (mpSystemNotificationsLibrary != null &&
                mpSystemSupportingItemLibrary != null)
            {

                EnterpriseManagementObject emoSCSMUser = null;
                //Criteria to get a user provided the email address
                string strCriteria = String.Format(@"
                    <Criteria xmlns=""http://Microsoft.EnterpriseManagement.Core.Criteria/"">
                        <Reference Id=""{0}"" Version=""{1}"" PublicKeyToken=""{2}"" Alias=""NotificationLibrary"" />
                        <Reference Id=""{3}"" Version=""{4}"" PublicKeyToken=""{5}"" Alias=""SupportingItemLibrary"" />
                        <Expression>
                            <SimpleExpression>
                              <ValueExpressionLeft>
                                <Property>$Target/Path[Relationship='SupportingItemLibrary!System.UserHasPreference' TypeConstraint='NotificationLibrary!System.Notification.Endpoint']/Property[Type='NotificationLibrary!System.Notification.Endpoint']/TargetAddress$</Property>
                              </ValueExpressionLeft>
                              <Operator>Equal</Operator>
                              <ValueExpressionRight>
                                <Value>{6}</Value>
                              </ValueExpressionRight>
                            </SimpleExpression>
                        </Expression>
                    </Criteria>",
                    mpSystemNotificationsLibrary.Name,
                    mpSystemNotificationsLibrary.Version.ToString(),
                    mpSystemNotificationsLibrary.KeyToken,
                    mpSystemSupportingItemLibrary.Name,
                    mpSystemSupportingItemLibrary.Version.ToString(),
                    mpSystemSupportingItemLibrary.KeyToken,
                    strEmailAddress);

                ManagementPackTypeProjection mptpUserPreferences = GetTypeProjectionByName("System.User.Preferences.Projection", emg);
                ObjectProjectionCriteria opcFindNotificationEndPointByEmailAddress = new ObjectProjectionCriteria(strCriteria, mptpUserPreferences, emg);

                IObjectProjectionReader<EnterpriseManagementObject> readerNotificationEndpoints = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(opcFindNotificationEndPointByEmailAddress, ObjectQueryOptions.Default);
                foreach (EnterpriseManagementObjectProjection emopNotificationEndpointItem in readerNotificationEndpoints)
                {
                    emoSCSMUser = emopNotificationEndpointItem.Object;
                }
                return (emoSCSMUser);
            }
            else
            {
                return null;
            }
        }

        public static IObjectProjectionReader<EnterpriseManagementObject> GetBufferedObjectProjectionReader(string strCriteria, int intNumberOfItemsToGet, ManagementPackTypeProjection mptp, EnterpriseManagementGroup emg)
        {
            ObjectProjectionCriteria opc = new ObjectProjectionCriteria(strCriteria, mptp, emg);
            ObjectQueryOptions oqo = new ObjectQueryOptions();
            oqo.ObjectRetrievalMode = ObjectRetrievalOptions.Buffered;
            oqo.MaxResultCount = intNumberOfItemsToGet;
            oqo.DefaultPropertyRetrievalBehavior = ObjectPropertyRetrievalBehavior.All;
            IObjectProjectionReader<EnterpriseManagementObject> reader = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(opc, oqo);
            return reader;
        }

        public static string SearchWorkItemByIDCriteriaXml(string strWorkItemID, string strMPName, string strMPVersion, string strMPPublicKeyToken, string strClassName)
        {
            strWorkItemID = MakeSafeXML(strWorkItemID);
            strMPName = MakeSafeXML(strMPName);
            strMPVersion = MakeSafeXML(strMPVersion);
            strMPPublicKeyToken = MakeSafeXML(strMPPublicKeyToken);
            strClassName = MakeSafeXML(strClassName);

            // This is XML that validates against the Microsoft.EnterpriseManagement.Core.Criteria schema.
            //This criteria will get a work item using the work item ID  
            string strCriteria = String.Format(@"
                <Criteria xmlns=""http://Microsoft.EnterpriseManagement.Core.Criteria/"">
                  <Reference Id=""{0}"" Version=""{1}"" PublicKeyToken=""{2}"" Alias=""WorkItemMP"" />
                    <Expression>
                        <SimpleExpression>
                            <ValueExpressionLeft>
                                <Property>$Target/Property[Type='WorkItemMP!{3}']/Id$</Property>
                            </ValueExpressionLeft>
                            <Operator>Equal</Operator>
                            <ValueExpressionRight>
                                <Value>{4}</Value>
                            </ValueExpressionRight>
                        </SimpleExpression>
                    </Expression>
                </Criteria>
                ", strMPName, strMPVersion, strMPPublicKeyToken, strClassName, strWorkItemID);

            return strCriteria;
        }

        public static string SearchWorkItemByLikeIDCriteriaXml(string strWorkItemID, string strMPName, string strMPVersion, string strMPPublicKeyToken, string strClassName)
        {
            strWorkItemID = MakeSafeXML(strWorkItemID);
            strMPName = MakeSafeXML(strMPName);
            strMPVersion = MakeSafeXML(strMPVersion);
            strMPPublicKeyToken = MakeSafeXML(strMPPublicKeyToken);
            strClassName = MakeSafeXML(strClassName);

            // This is XML that validates against the Microsoft.EnterpriseManagement.Core.Criteria schema.
            //This criteria will get a bunch of work items using LIKE on the work item ID  
            string strCriteria = String.Format(@"
                <Criteria xmlns=""http://Microsoft.EnterpriseManagement.Core.Criteria/"">
                  <Reference Id=""{0}"" Version=""{1}"" PublicKeyToken=""{2}"" Alias=""WorkItemMP"" />
                    <Expression>
                        <SimpleExpression>
                            <ValueExpressionLeft>
                                <Property>$Target/Property[Type='WorkItemMP!{3}']/Id$</Property>
                            </ValueExpressionLeft>
                            <Operator>Like</Operator>
                            <ValueExpressionRight>
                                <Value>%{4}%</Value>
                            </ValueExpressionRight>
                        </SimpleExpression>
                    </Expression>
                </Criteria>
                ", strMPName, strMPVersion, strMPPublicKeyToken, strClassName, strWorkItemID);

            return strCriteria;
        }

        public static string SearchObjectByEnumerationCriteriaXml(ManagementPackEnumeration mpe, ManagementPackClass mpc, ManagementPackProperty mpp)
        {
            ManagementPack mp = mpc.GetManagementPack();
            string strMPName = MakeSafeXML(mp.Name);
            string strMPVersion = MakeSafeXML(mp.Version.ToString());
            string strMPPublicKeyToken = MakeSafeXML(mp.KeyToken);
            string strClassName = MakeSafeXML(mpc.Name);
            string strPropertyName = MakeSafeXML(mpp.Name);

            // This is XML that validates against the Microsoft.EnterpriseManagement.Core.Criteria schema.
            string strCriteria = String.Format(@"
                <Criteria xmlns=""http://Microsoft.EnterpriseManagement.Core.Criteria/"">
                  <Reference Id=""{0}"" Version=""{1}"" PublicKeyToken=""{2}"" Alias=""MP"" />
                    <Expression>
                        <SimpleExpression>
                            <ValueExpressionLeft>
                                <Property>$Target/Property[Type='MP!{3}']/{4}$</Property>
                            </ValueExpressionLeft>
                            <Operator>Equal</Operator>
                            <ValueExpressionRight>
                                <Value>{{{5}}}</Value>
                            </ValueExpressionRight>
                        </SimpleExpression>
                    </Expression>
                </Criteria>
                ", strMPName, strMPVersion, strMPPublicKeyToken, strClassName, strPropertyName, mpe.Id.ToString());

            return strCriteria;
        }

        public static string MakeSafeXML(string stringToMakeSafe)
        {
            //Escapes XML special characters
            stringToMakeSafe = stringToMakeSafe.Replace("&", "&amp;");
            stringToMakeSafe = stringToMakeSafe.Replace("'", "&apos;");
            stringToMakeSafe = stringToMakeSafe.Replace("\"", "&quot;");
            stringToMakeSafe = stringToMakeSafe.Replace("<", "&lt;");
            stringToMakeSafe = stringToMakeSafe.Replace(">", "&gt;");
            return stringToMakeSafe;
        }

        public static int GetRandomNumber(int intMin, int intMax)
        {
            Random r = new Random();
            return r.Next(intMin, intMax);
        }

        public static string MakeMPElementSafeName(string strName)
        {
            //strip out any non alpha numeric characters
            strName = Regex.Replace(strName, @"[^a-zA-Z0-9]", "");
            //MP element names cant be longer than 255 characters so shorten it up if needed
            if (strName.Length > 254)
                strName = strName.Substring(0, 254);

            return strName;
        }
    }
}
