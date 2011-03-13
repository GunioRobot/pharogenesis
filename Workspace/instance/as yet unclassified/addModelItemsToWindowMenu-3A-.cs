addModelItemsToWindowMenu: aMenu
	aMenu addLine.
	aMenu add: 'save contents to file...' target: self action: #saveContentsInFile.
	
	self acceptsDroppingMorphForReference 
		ifTrue: [aMenu 
					add: 'cease accepting dropping morph for reference' 
					target: self 
					action: #toggleDroppingMorphForReference] 
		ifFalse: [aMenu 
					add: 'start accepting dropping morph for reference' 
					target: self 
					action: #toggleDroppingMorphForReference] 