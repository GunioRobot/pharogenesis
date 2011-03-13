holderWithAlphabet
	"Answer a fully instantiated Holder that has submorphs that represent the letters of the uppercase alphabet, with each one having an 'index' slot which bears the letter's index in the alphabet -- 1 for A, 2 for B, etc.   A few special characters are provided as per ack request 10/00; for these the index provided is rather arbitrarily assigned"

	| aMorph aPlayer newMorph oneCharString aContainer aWrapper |

	"ScriptingSystem holderWithAlphabet openInHand"

	aContainer _ self prototypicalHolder useRoundedCorners.
	aContainer borderColor: Color blue lighter.

	aWrapper _ AlignmentMorph new hResizing: #shrinkWrap; vResizing: #shrinkWrap; layoutInset: 0.
	aWrapper addMorphBack: (aMorph _ TextMorph new contents: 'A').
	aMorph beAllFont: ((TextStyle named: Preferences standardEToysFont familyName) fontOfSize: 24).
	aMorph width: 14; lock.
	aWrapper beTransparent; setNameTo: 'A'.
	aPlayer _ aWrapper assuredPlayer.
	aPlayer addInstanceVariableNamed: #index type: #Number value: 1.
	aContainer addMorphBack: aWrapper.
	2 to: 26 do:
		[:anIndex |
			newMorph _ aWrapper usableSiblingInstance.
			newMorph player perform: #setIndex: with: anIndex.
			newMorph firstSubmorph contents: (oneCharString _ ($A asciiValue + anIndex - 1) asCharacter asString).
			newMorph setNameTo: oneCharString.

			aContainer addMorphBack: newMorph].

	#(' ' '.' '#') with: #(27 28 29) do:
		[:aString :anIndex |
			newMorph _ aWrapper usableSiblingInstance.
			newMorph player perform: #setIndex: with: anIndex.
			newMorph firstSubmorph contents: aString.
			aString = ' '
				ifTrue:
					[newMorph setNameTo: 'space'.
					newMorph color: (Color gray alpha: 0.2)]
				ifFalse:
					[newMorph setNameTo: aString].
			aContainer addMorphBack: newMorph].

	aContainer setNameTo: 'alphabet'.
	aContainer isPartsBin: true.
	aContainer enableDrop: false.
	aContainer indicateCursor: false; width: 162.
	aContainer color: (Color r: 0.839 g: 1.0 b: 1.0).  "Color fromUser"
	^ aContainer