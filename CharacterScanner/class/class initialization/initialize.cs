initialize
	"CharacterScanner initialize"
	"NewCharacterScanner initialize"
	| stopConditions |
	stopConditions _ Array new: 258.
	stopConditions atAllPut: nil.
	stopConditions at: Space asciiValue + 1 put: nil.
	stopConditions at: Tab asciiValue + 1 put: #tab.
	stopConditions at: CR asciiValue + 1 put: #cr.
	stopConditions at: EndOfRun put: #endOfRun.
	stopConditions at: CrossedX put: #crossedX.
	DefaultStopConditions _ stopConditions.