
function MakeMPElementIDSafeName 
{
    param([string]$name, [string]$element)
    $return = $name + "." + $element
    # be sure that we done
    $disallowed = '!@#$%^&*()_-+={}[]|\:?/<>.~;''" '.ToCharArray()
    foreach ($char in $disallowed)
    {
        $return = $return.Replace($char,"_")
    }
    $return
}

$file = "C:\Users\administrator.CONTOSO\Documents\Visual Studio 2010\Projects\PerfTestHarness\SupportGroups.txt"
$SupportGroups = Get-Content $file

Import-Module SMLets

$IncidentParentSupportGroupEnum = "IncidentTierQueuesEnum"

$IncidentSuffix = "-IN"
$ChangeRequestSuffix = "-CR"
$ProblemSuffix = "-PR"
$ServiceRequestSuffix = "-SR"

$ADUserGroupNamePrefix = "SCSM-"
$ADUserGroupNameNotificationRecipientPrefix = "SCSM-"
$ADUserGroupNameNotificationRecipientSuffix = "-FE"

$NotificationSubscriptionUpdateSuffix = "-U"
$NotificationSubscriptionCreateSuffix = "-C"

$NotificationSubscriptionStatusCompletedSuffix = "-Completed"
$NotificationSubscriptionStatusClosedSuffix = "-Closed"
$NotificationSubscriptionStatusResolvedSuffix = "-Resolved"

$EnumElement = "Enum"
$QueueElement = "Queue"
$Subscription = "Subscription"
$ManagementPack = "ManagementPack"

$UserRoleIncidentResolverNameSuffix = " Incident Resolvers"
$UserRoleChangeRequestManagerNameSuffix = " Change Managers"
$UserRoleProblemAnalystNameSuffix = " Problem Analysts"
$UserRoleServiceRequestAnalystNameSuffix = " Service Request Analysts"

#Get-Classes
$IncidentClass = Get-SCSMClass -Name System.WorkItem.Incident$
$ChangeRequestClass = Get-SCSMClass -Name System.WorkItem.ChangeRequest$
$ProblemClass = Get-SCSMClass -Name System.WorkItem.Problem$
$ServiceRequestClass = Get-SCSMClass -Name System.WorkItem.ServiceRequest$

#Get User Role Profiles
$IncidentResolverUserRoleProfile = Get-SCSMUserRoleProfile -Name IncidentResolver
$ChangeManagerUserRoleProfile = Get-SCSMUserRoleProfile -Name ChangeManager
$ProblemAnalystUserRoleProfile = Get-SCSMUserRoleProfile -Name ProblemAnalyst
$ServiceRequestAnalystUserRoleProfile = Get-SCSMUserRoleProfile -Name ServiceRequestAnalyst

#Get a notification template
$IncidentNotificationTemplate = Get-SCSMObjectTemplate -Name IncidentNotificationTemplate
$ChangeRequestNotificationTemplate = Get-SCSMObjectTemplate -Name ChangeRequestNotificationTemplate
$ProblemNotificationTemplate = Get-SCSMObjectTemplate -Name ProblemNotificationTemplate
$ServiceRequestNotificationTemplate = Get-SCSMObjectTemplate -Name ServiceRequestNotificationTemplate

$SupportGroupParentEnum = Get-SCSMEnumeration -Name $IncidentParentSupportGroupEnum$
$ServiceRequestStatusCompleted = (Get-SCSMEnumeration -Name ServiceRequestStatusEnum.Completed).Id
$ServiceRequestStatusClosed = (Get-SCSMEnumeration -Name ServiceRequestStatusEnum.Closed).Id
$ChangeRequestStatusCompleted = (Get-SCSMEnumeration -Name ChangeStatusEnum.Completed).Id
$ChangeRequestStatusClosed = (Get-SCSMEnumeration -Name ChangeStatusEnum.Closed).Id
$IncidentStatusClosed = (Get-SCSMEnumeration -Name IncidentStatusEnum.Closed).Id
$IncidentStatusResolved = (Get-SCSMEnumeration -Name IncidentStatusEnum.Resolved).Id

if($SupportGroups.Count -gt 0) { $count = $SupportGroups.Count } else { $count = 1 }
$i = 0

foreach($SupportGroupDisplayName in $SupportGroups)
{
    $i++
    Write-Progress -Activity "Creating support group configuration..." -Status "Working on $SupportGroupDisplayName ($i of $count)" -PercentComplete (($i/$count)*100)
    
    $SupportGroupName = MakeMPElementIDSafeName $SupportGroupDisplayName $EnumElement
    $SupportGroupManagementPackDisplayName = $SupportGroupDisplayName
    $SupportGroupManagementPackName = MakeMPElementIDSafeName $SupportGroupManagementPackDisplayName $ManagementPack
    $SupportGroupQueueIncidentDisplayName = $SupportGroupDisplayName + $IncidentSuffix
    $SupportGroupQueueIncidentName = MakeMPElementIDSafeName $SupportGroupQueueIncidentDisplayName $QueueElement
    $SupportGroupQueueChangeRequestDisplayName = $SupportGroupDisplayName + $ChangeRequestSuffix
    $SupportGroupQueueChangeRequestName = MakeMPElementIDSafeName $SupportGroupQueueChangeRequestDisplayName $QueueElement
    $SupportGroupQueueProblemDisplayName = $SupportGroupDisplayName + $ProblemSuffix
    $SupportGroupQueueProblemName = MakeMPElementIDSafeName $SupportGroupQueueProblemDisplayName $QueueElement
    $SupportGroupQueueServiceRequestDisplayName = $SupportGroupDisplayName + $ServiceRequestSuffix
    $SupportGroupQueueServiceRequestName = MakeMPElementIDSafeName $SupportGroupQueueServiceRequestDisplayName $QueueElement
    $SupportGroupIncidentResolverUserRoleDisplayName = $SupportGroupDisplayName + $IncidentSuffix + $UserRoleIncidentResolverNameSuffix
    $SupportGroupChangeRequestManagerUserRoleDisplayName = $SupportGroupDisplayName + $ChangeRequestSuffix + $UserRoleChangeRequestManagerNameSuffix
    $SupportGroupProblemAnalystUserRoleDisplayName = $SupportGroupDisplayName + $ProblemSuffix + $UserRoleProblemAnalystNameSuffix
    $SupportGroupServiceRequestAnalystUserRoleDisplayName = $SupportGroupDisplayName + $ServiceRequestSuffix + $UserRoleServiceRequestAnalystNameSuffix
    $SupportGroupADGroupName = $SupportGroupDisplayName
    $SupportGroupADGroupNameNotificationRecipient = $SupportGroupDisplayName + "User"
    
    #Notification Subscription Display Names
    $NotificationSubscriptionIncidentCreateDisplayName = $SupportGroupDisplayName + $IncidentSuffix + $NotificationSubscriptionCreateSuffix
    $NotificationSubscriptionIncidentUpdateDisplayName = $SupportGroupDisplayName + $IncidentSuffix + $NotificationSubscriptionUpdateSuffix
    $NotificationSubscriptionChangeRequestCreateDisplayName = $SupportGroupDisplayName + $ChangeRequestSuffix + $NotificationSubscriptionCreateSuffix
    $NotificationSubscriptionChangeRequestUpdateDisplayName = $SupportGroupDisplayName + $ChangeRequestSuffix + $NotificationSubscriptionUpdateSuffix
    $NotificationSubscriptionProblemCreateDisplayName = $SupportGroupDisplayName + $ProblemSuffix + $NotificationSubscriptionCreateSuffix
    $NotificationSubscriptionProblemUpdateDisplayName = $SupportGroupDisplayName + $ProblemSuffix + $NotificationSubscriptionUpdateSuffix
    $NotificationSubscriptionServiceRequestCreateDisplayName = $SupportGroupDisplayName + $ServiceRequestSuffix + $NotificationSubscriptionCreateSuffix
    $NotificationSubscriptionServiceRequestUpdateDisplayName = $SupportGroupDisplayName + $ServiceRequestSuffix + $NotificationSubscriptionUpdateSuffix
    $NotificationSubscriptionServiceRequestCompletedUpdateDisplayName = $SupportGroupDisplayName + $ServiceRequestSuffix + $NotificationSubscriptionUpdateSuffix + $NotificationSubscriptionStatusCompletedSuffix
    $NotificationSubscriptionServiceRequestClosedUpdateDisplayName = $SupportGroupDisplayName + $ServiceRequestSuffix + $NotificationSubscriptionUpdateSuffix + $NotificationSubscriptionStatusClosedSuffix
    $NotificationSubscriptionIncidentClosedUpdateDisplayName = $SupportGroupDisplayName + $IncidentSuffix + $NotificationSubscriptionUpdateSuffix + $NotificationSubscriptionStatusClosedSuffix
    $NotificationSubscriptionIncidentResolvedUpdateDisplayName = $SupportGroupDisplayName + $IncidentSuffix + $NotificationSubscriptionUpdateSuffix + $NotificationSubscriptionStatusResolvedSuffix
    $NotificationSubscriptionChangeRequestCompletedUpdateDisplayName = $SupportGroupDisplayName + $ChangeRequestSuffix + $NotificationSubscriptionUpdateSuffix + $NotificationSubscriptionStatusCompletedSuffix
    $NotificationSubscriptionChangeRequestClosedUpdateDisplayName = $SupportGroupDisplayName + $ChangeRequestSuffix + $NotificationSubscriptionUpdateSuffix + $NotificationSubscriptionStatusClosedSuffix
    
    #Get User and Group
    $SupportGroupADUserGroupObject = Get-SCSMObject -Class (Get-SCSMClass -Name System.Domain.User) -Filter "UserName = $SupportGroupADGroupName"
    $NotificationRecipientADUserGroupObject = Get-SCSMObject -Class (Get-SCSMClass  -Name System.Domain.User) -Filter "UserName = $SupportGroupADGroupNameNotificationRecipient"
    
    #Create MP
    $SupportGroupManagementPack = New-SCManagementPack -ManagementPackName $SupportGroupManagementPackName -FriendlyName $SupportGroupManagementPackDisplayName -PassThru

    #Create Enums
    $SupportGroupEnumeration = Add-SCSMEnumeration -Parent $SupportGroupParentEnum -Name $SupportGroupName -DisplayName $SupportGroupDisplayName -ManagementPack $SupportGroupManagementPack -Ordinal $i -PassThru
    $SupportGroupEnumerationId = $SupportGroupEnumeration.Id
    
    #Create Queues
    $IncidentQueueClass = New-SCQueue -Name $SupportGroupQueueIncidentDisplayName -ManagementPack $SupportGroupManagementPack -Class $IncidentClass -Filter "TierQueue =  '$SupportGroupEnumerationId'" -PassThru
    $IncidentQueue = Get-SCSMObject -Class $IncidentQueueClass

    $ChangeRequestQueueClass = New-SCQueue -Name $SupportGroupQueueChangeRequestDisplayName -ManagementPack $SupportGroupManagementPack -Class $ChangeRequestClass -Filter "TierQueue =  '$SupportGroupEnumerationId'" -PassThru
    $ChangeRequestQueue = Get-SCSMObject -Class $ChangeRequestQueueClass
    
    $ProblemQueueClass = New-SCQueue -Name $SupportGroupQueueProblemDisplayName -ManagementPack $SupportGroupManagementPack -Class $ProblemClass -Filter "TierQueue =  '$SupportGroupEnumerationId'" -PassThru
    $ProblemQueue = Get-SCSMObject -Class $ProblemQueueClass

    $ServiceRequestQueueClass = New-SCQueue -Name $SupportGroupQueueServiceRequestDisplayName -ManagementPack $SupportGroupManagementPack -Class $ServiceRequestClass -Filter "TierQueue =  '$SupportGroupEnumerationId'" -PassThru
    $ServiceRequestQueue = Get-SCSMObject -Class $ServiceRequestQueueClass
    
    #Create Subscriptions
$IncidentSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_Incident_Library!System.WorkItem.Incident']/TierQueue`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$SupportGroupEnumerationId}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"

    New-SCSMNotificationSubscription -Class $IncidentClass -DisplayName $NotificationSubscriptionIncidentCreateDisplayName  -NotificationTemplate $IncidentNotificationTemplate -Criteria $IncidentSubscriptionCriteria -OperationType "Add" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
    New-SCSMNotificationSubscription -Class $IncidentClass -DisplayName $NotificationSubscriptionIncidentUpdateDisplayName  -NotificationTemplate $IncidentNotificationTemplate -Criteria $IncidentSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack

    #**** NOTE ***** This criteria assumes that there is an extended property on the change request class with the name 'TierQueue' that is bound to IncidentTierQueuesEnum
$ChangeRequestSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_ChangeRequest_Library!System.WorkItem.ChangeRequest']/TierQueue`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$SupportGroupEnumerationId}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"
    
    New-SCSMNotificationSubscription -Class $ChangeRequestClass -DisplayName $NotificationSubscriptionChangeRequestCreateDisplayName  -NotificationTemplate $ChangeRequestNotificationTemplate -Criteria $ChangeRequestSubscriptionCriteria -OperationType "Add" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
    New-SCSMNotificationSubscription -Class $ChangeRequestClass -DisplayName $NotificationSubscriptionChangeRequestUpdateDisplayName  -NotificationTemplate $ChangeRequestNotificationTemplate -Criteria $ChangeRequestSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
    
    
#**** NOTE ***** This criteria assumes that there is an extended property on the Problem class with the name 'TierQueue' that is bound to IncidentTierQueuesEnum
$ProblemSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_Problem_Library!System.WorkItem.Problem']/TierQueue`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$SupportGroupEnumerationId}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"
    
    New-SCSMNotificationSubscription -Class $ProblemClass -DisplayName $NotificationSubscriptionProblemCreateDisplayName  -NotificationTemplate $ProblemNotificationTemplate -Criteria $ProblemSubscriptionCriteria -OperationType "Add" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
    New-SCSMNotificationSubscription -Class $ProblemClass -DisplayName $NotificationSubscriptionProblemUpdateDisplayName  -NotificationTemplate $ProblemNotificationTemplate -Criteria $ProblemSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack        
    
    
    #**** NOTE ***** This criteria assumes that there is an extended property on the Service Request class with the name 'TierQueue' that is bound to IncidentTierQueuesEnum
$ServiceRequestSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_ServiceRequest_Library!System.WorkItem.ServiceRequest']/TierQueue`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$SupportGroupEnumerationId}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"
    
    New-SCSMNotificationSubscription -Class $ServiceRequestClass -DisplayName $NotificationSubscriptionServiceRequestCreateDisplayName  -NotificationTemplate $ServiceRequestNotificationTemplate -Criteria $ServiceRequestSubscriptionCriteria -OperationType "Add" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
    New-SCSMNotificationSubscription -Class $ServiceRequestClass -DisplayName $NotificationSubscriptionServiceRequestUpdateDisplayName  -NotificationTemplate $ServiceRequestNotificationTemplate -Criteria $ServiceRequestSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack        
      
      
      
$ServiceRequestCompletedSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_ServiceRequest_Library!System.WorkItem.ServiceRequest']/Status`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$ServiceRequestStatusCompleted}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"

$ServiceRequestClosedSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_ServiceRequest_Library!System.WorkItem.ServiceRequest']/Status`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$ServiceRequestStatusClosed}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"      
      
      New-SCSMNotificationSubscription -Class $ServiceRequestClass -DisplayName $NotificationSubscriptionServiceRequestCompletedUpdateDisplayName  -NotificationTemplate $ServiceRequestNotificationTemplate -Criteria $ServiceRequestCompletedSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack        
      New-SCSMNotificationSubscription -Class $ServiceRequestClass -DisplayName $NotificationSubscriptionServiceRequestClosedUpdateDisplayName  -NotificationTemplate $ServiceRequestNotificationTemplate -Criteria $ServiceRequestClosedSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack        
            
$ChangeRequestCompletedSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_ChangeRequest_Library!System.WorkItem.ChangeRequest']/Status`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$ChangeRequestStatusCompleted}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"


$ChangeRequestClosedSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_ChangeRequest_Library!System.WorkItem.ChangeRequest']/Status`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$ChangeRequestStatusClosed}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"

New-SCSMNotificationSubscription -Class $ChangeRequestClass -DisplayName $NotificationSubscriptionChangeRequestCompletedUpdateDisplayName  -NotificationTemplate $ChangeRequestNotificationTemplate -Criteria $ChangeRequestCompletedSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
New-SCSMNotificationSubscription -Class $ChangeRequestClass -DisplayName $NotificationSubscriptionChangeRequestClosedUpdateDisplayName  -NotificationTemplate $ChangeRequestNotificationTemplate -Criteria $ChangeRequestClosedSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack

$IncidentResolvedSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_Incident_Library!System.WorkItem.Incident']/Status`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$IncidentStatusResolved}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"
  
  
$IncidentClosedSubscriptionCriteria = "
  <Criteria>
    <Expression>
      <SimpleExpression>
        <ValueExpression>
          <Property State=`"Post`">`$Context/Property[Type='System_WorkItem_Incident_Library!System.WorkItem.Incident']/Status`$</Property>
        </ValueExpression>
        <Operator>Equal</Operator>
        <ValueExpression>
          <Value>{$IncidentStatusClosed}</Value>
        </ValueExpression>
      </SimpleExpression>
    </Expression>
  </Criteria>"
  
    New-SCSMNotificationSubscription -Class $IncidentClass -DisplayName $NotificationSubscriptionIncidentResolvedUpdateDisplayName  -NotificationTemplate $IncidentNotificationTemplate -Criteria $IncidentResolvedSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
    New-SCSMNotificationSubscription -Class $IncidentClass -DisplayName $NotificationSubscriptionIncidentClosedUpdateDisplayName  -NotificationTemplate $IncidentNotificationTemplate -Criteria $IncidentClosedSubscriptionCriteria -OperationType "Update" -Recipients $NotificationRecipientADUserGroupObject -ManagementPack $SupportGroupManagementPack
      
      
    New-SCSMUserRole -DisplayName $SupportGroupIncidentResolverUserRoleDisplayName -Profile $IncidentResolverUserRoleProfile -Objects $IncidentQueue -SCSMUsers $SupportGroupADUserGroupObject -AllTemplates
    #New-SCSMUserRole -DisplayName $SupportGroupChangeRequestManagerUserRoleDisplayName -Profile $ChangeManagerUserRoleProfile -Objects $ChangeRequestQueue -SCSMUsers $SupportGroupADUserGroupObject -AllTemplates
    #New-SCSMUserRole -DisplayName $SupportGroupProblemAnalystUserRoleDisplayName -Profile $ProblemAnalystUserRoleProfile -Objects $ProblemQueue -SCSMUsers $SupportGroupADUserGroupObject -AllTemplates
    New-SCSMUserRole -DisplayName $SupportGroupServiceRequestAnalystUserRoleDisplayName -Profile $ServiceRequestAnalystUserRoleProfile -Objects $ServiceRequestQueue -SCSMUsers $SupportGroupADUserGroupObject -AllTemplates
}