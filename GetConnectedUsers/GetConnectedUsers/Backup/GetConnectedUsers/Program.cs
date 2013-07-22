/*
 GetConnectedUsers.exe
 
 Description:
 GetConnectedUsers.exe optionally takes a server name to connect to,
 connects to the Service Manager SDK and outputs a list of the domain\
 usernames of the connected users to the standard out.
 
 Copyright(c) Microsoft.  All rights reserved.
 This code is licensed under the Microsoft Public License.
 http://www.microsoft.com/opensource/licenses.mspx
 
 THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND,
 EITHER EXPRESSED OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES
 OF FITNESS FOR A PARITCULAR PURPOSE, MERCHANTABILITY, OR
 NON-INFRINGEMENT.
 
 Original Author: Travis Wright (twright@microsoft.com)
 Original Creation Date: Feb 1, 2010
 Original Version: 1.0
*/ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommadLineArgumentParser;
using Microsoft.EnterpriseManagement;

namespace GetConnectedUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string strManagementServer = null;

            CommadLineArgumentParser.Arguments strArrayArguments = new Arguments(args);

            if (strArrayArguments["Server"] != null)
            {
                strManagementServer = strArrayArguments["Server"];
            }
            else
            {
                strManagementServer = "localhost";
            }

            EnterpriseManagementGroup emo = new EnterpriseManagementGroup(strManagementServer);
            foreach (String strIUserName in emo.GetConnectedUserNames())
            {
                Console.WriteLine(strIUserName.ToString());
            }
        }
    }
}
