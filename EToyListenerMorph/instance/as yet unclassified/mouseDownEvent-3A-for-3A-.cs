mouseDownEvent: event for: aMorph 
	| menu selection depictedObject |
	depictedObject := aMorph firstSubmorph valueOfProperty: #depictedObject.
	menu := CustomMenu new.
	menu
		add: 'Grab' action: [event hand attachMorph: depictedObject veryDeepCopy];
		add: 'Delete'
			action: 
				[self class removeFromGlobalIncomingQueue: depictedObject.
				self rebuild].
	selection := menu build startUpCenteredWithCaption: 'Morph from ' 
						, (aMorph submorphs second) firstSubmorph contents.
	selection ifNil: [^self].
	selection value