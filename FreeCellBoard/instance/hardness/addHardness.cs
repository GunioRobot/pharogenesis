addHardness
	| cnt rand pileInd pile |
	"post process the layout of cards to make it harder.  See class comment."

	hardness ifNil: [^ self].
	cnt _ hardness.
	rand _ Random new seed: cardDeck seed.  "Same numbers but different purpose"
	pileInd _ 1. 
	[(cnt _ cnt - 1) > 0] whileTrue: [
		pile _ stacks atWrap: (pileInd _ pileInd + 1).
		cnt _ cnt - (self makeHarder: pile rand: rand toDo: cnt)].  "mostly 0, but moves cards"