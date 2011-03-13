subclassTemplate: aClassNode 
	| class definition |
	class _ aClassNode theNonMetaClass.
	definition _ (OBClassDefinition 
					environment: class environment 
					template: (Class 
								templateForSubclassOf: class 
								category: class category)).
	definition signalChange.