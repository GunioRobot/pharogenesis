mouseDownEvent: event for: aMorph

	| menu selection depictedObject |

	depictedObject _ aMorph firstSubmorph valueOfProperty: #depictedObject.
	menu _ CustomMenu new.
	menu 
		add: 'Grab' 
		action: [
			event hand attachMorph: depictedObject veryDeepCopy
		];
		add: 'Delete' 
		action: [
			self class removeFromGlobalIncomingQueue: depictedObject.
			self rebuild.
		].
	selection _ menu build startUpCenteredWithCaption: 'Morph from ',
					(aMorph submorphs at: 2) firstSubmorph contents.
	selection ifNil: [^self].
	selection value.
