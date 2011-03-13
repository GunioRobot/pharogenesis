ditchOldChangeSetFor: aFileName 

	| changeSetName |
 
	changeSetName := (self validChangeSetName: aFileName) sansPeriodSuffix.


	(self classChangeSet named: changeSetName)
		ifNotNil: [  	
				(self logCR:'Removing old change set ', changeSetName) cr.
				self classChangeSet removeChangeSet: (self classChangeSet named: changeSetName) ].