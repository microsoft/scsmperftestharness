The EnumGen tool will generate a enumeration hierarchy based on any root enumeration, n levels deep and n number of enums per level.  This tool is currently intended just to generate test data given that the enumeration value display names will be things like 'Enum Value 1.1', 'Enum Value 1.1.1' etc.

Just run the tool and then specify the parameters:
* **SCSM Server Name:** specify the server name to connect to or if you are running it local on the SCSM management server you can use localhost.
* **New MP Name:** specify the name of the MP.  This will be used for the MP name, friendly name, display name, and file name.  A .xml file will be created.  If you want to create a .mp file you will need to use a tool like fastseal.exe.
* **Base Enum Name:** This is the internal name of the base enumeration that you want to create all enumerations from.   By default this is set to IncidentClassificationEnum which is the base enum for System.WorkItem.Incident.Classification.  You can look up an enum's internal name using SMLets.
* **Number of levels to create:** This is the number of levels of hierarchy to create.
* **Number of enums to create per level:** This is the number of enumeration values to create at each level in the hierarchy.
* **Folder to write the MP file to:** This is the location to write the .xml file to when done.

Note: the tool will prompt you before committing the changes to disk how many enumerations will be created.  You can choose Yes|No at that point.



