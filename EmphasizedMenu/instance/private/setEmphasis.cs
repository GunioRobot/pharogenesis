setEmphasis
	"Set up the receiver to reflect the emphases in the emphases array.  "

	| selStart selEnd currEmphasis |
	
	labelString _ labelString asText.
	emphases isEmptyOrNil ifTrue: [^ self].
	selStart _ 1.
	1 to: selections size do:
		[:line |
			selEnd _ selStart + (selections at: line) size - 1.
			((currEmphasis _ emphases at: line) size > 0 and: [currEmphasis ~~ #normal]) ifTrue:
				[labelString addAttribute: (TextEmphasis perform: currEmphasis)
					from: selStart to: selEnd].
			selStart _ selEnd + 2]