abstractAModel
	"Find data-containing fields in me.  Make a new class, whose instance variables are named for my fields, and whose values are the values I am showing.  Use a CardPlayer for now.  Force the user to name the fields.  Make slots for text, Number Watchers, SketchMorphs, and ImageMorphs."

	| instVarNames unnamed ans player twoListsOfMorphs holdsSepData docks oldPlayer iVarName |
	(oldPlayer := self player) ifNotNil: 
			[oldPlayer belongsToUniClass 
				ifTrue: 
					["Player"

					oldPlayer class instVarNames notEmpty 
						ifTrue: 
							[self 
								inform: 'I already have a regular Player, so I can''t have a CardPlayer'.
							^true]]].
	twoListsOfMorphs := StackMorph discoverSlots: self.
	holdsSepData := twoListsOfMorphs first.
	instVarNames := ''.
	holdsSepData do: 
			[:ea | 
			iVarName := Utilities wellFormedInstanceVariableNameFrom: ea knownName.
			iVarName = ea knownName ifFalse: [ea name: iVarName].
			instVarNames := instVarNames , iVarName , ' '].
	unnamed := twoListsOfMorphs second.	"have default names"
	instVarNames isEmpty 
		ifTrue: 
			[self 
				inform: 'No named fields were found.
Please get a halo on each field and give it a name.
Labels or non-data fields should be named "shared xxx".'.
			^false].
	unnamed notEmpty 
		ifTrue: 
			[ans := PopUpMenu 
						confirm: 'Data fields are ' , instVarNames printString 
								, ('\Some fields are not named.  Are they labels or non-data fields?' 
										, '\Please get a halo on each data field and give it a name.') withCRs
						trueChoice: 'All other fields are non-data fields'
						falseChoice: 'Stop.  Let me give a name to some more fields'.
			ans ifFalse: [^false]].
	unnamed 
		withIndexDo: [:mm :ind | mm setName: 'shared label ' , ind printString].
	"Make a Player with instVarNames.  Make me be the costume"
	player := CardPlayer instanceOfUniqueClassWithInstVarString: instVarNames
				andClassInstVarString: ''.
	self player: player.
	player costume: self.
	"Fill in the instance values.  Make docks first."
	docks := OrderedCollection new.
	holdsSepData do: 
			[:morph | 
			morph setProperty: #shared toValue: true.	"in case it is deeply embedded"
			morph setProperty: #holdsSeparateDataForEachInstance toValue: true.
			player class compileInstVarAccessorsFor: morph knownName.
			morph isSyntaxMorph ifTrue: [morph setTarget: player].	"hookup the UpdatingString!"
			docks addAll: morph variableDocks].
	player class newVariableDocks: docks.
	docks do: [:dd | dd storeMorphDataInInstance: player].
	"oldPlayer class mdict do: [:assoc | move to player].	move methods to new class?"
	"oldPlayer become: player."
	^true	"success"