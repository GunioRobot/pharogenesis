genericMenu: aMenu

	| insideObject menu |
	currentSelection ifNil:
		[menu _ aMenu.
		menu add: '*nothing selected*' target: self selector: #yourself]
	 ifNotNil:
		[menu _ DumberMenuMorph new defaultTarget: self.
		insideObject _ currentSelection withoutListWrapper.
		menu 
			add: 'explore' target: insideObject  selector: #explore;
			add: 'inspect' target: insideObject  selector: #inspect;
			addLine;
			add: 'objects pointing to this value' target: Smalltalk  selector:  #browseAllObjectReferencesTo:except:ifNone:  argumentList: (Array with: insideObject with: #() with: nil);
			addLine;
			add: 'browse full' target: Browser  selector: #fullOnClass:  argument: insideObject class;
			add: 'browse class' target: insideObject class  selector: #browse;
			add: 'browse hierarchy' target: Utilities  selector:  #spawnHierarchyForClass:selector: argumentList: (Array with: insideObject class with: nil)].

	^ menu