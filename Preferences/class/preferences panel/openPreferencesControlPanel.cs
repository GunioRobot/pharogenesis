openPreferencesControlPanel
	"Preferences openPreferencesControlPanel"
	| aPanel aWindow aRow wrapper but aList odd aColor w width1 width2 spacer |
	Smalltalk verifyMorphicAvailability ifFalse: [^ self beep].
	true ifTrue: [^ self openFactoredPanel].

	"What follows below is the former (pre-2.8alpha) implementation of the prefs panel"

	aPanel _ AlignmentMorph newColumn.
	aPanel beSticky.
	aList _ OrderedCollection new.
	FlagDictionary associationsDo: [:assoc | aList add: (Array
				with: assoc key
				with: assoc value
				with: (self helpMessageForPreference: assoc key))].
	odd _ false.
	width1 _ 172.
	spacer _ 4.
	width2 _ 14.
	(aList asSortedCollection: [:a :b | a first < b first])
		do: 
			[:triplet | 
			aPanel addMorphBack: (aRow _ AlignmentMorph newRow).
			aRow color: (aColor _ odd
							ifTrue: [Color green muchLighter]
							ifFalse: [Color red veryMuchLighter]).
			odd _ odd not.
			aRow addMorph: (wrapper _ Morph new color: aColor).
			wrapper setBalloonText: triplet third.
			wrapper extent: width1 @ 15.
			wrapper addMorph: (StringMorph new contents: triplet first).
			aRow addMorphBack: (Morph new color: aColor; extent: (spacer @ 15)).
			aRow addMorphBack: (wrapper _ Morph new color: aColor).
			wrapper extent: width2 @ 15.
			wrapper addMorphBack: (but _ UpdatingBooleanStringMorph new contents: triplet second printString).
			but getSelector: triplet first;
			putSelector: #setPreference:toValue:;
			stepTime: 1800;
			 target: self].
		wrapper _ ScrollPane new.
		wrapper scroller addMorph: aPanel.
	Smalltalk isMorphic
		ifTrue:
			[aWindow _ SystemWindow new model: self.
			aWindow addMorph: wrapper frame: (0 @ 0 extent: 1 @ 1).
			aWindow setLabel: 'Preferences'.
			aWindow openInWorld] 
		ifFalse:
			[(w _ MVCWiWPasteUpMorph newWorldForProject: nil)
						addMorph: wrapper.
			wrapper
				retractable: false;
				extent: self initialExtent + (wrapper scrollbarWidth @ 0).
			w startSteppingSubmorphsOf: wrapper.
			MorphWorldView openOn: w
				label: 'Preferences'
				extent: w fullBounds extent]
