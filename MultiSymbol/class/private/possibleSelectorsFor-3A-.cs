possibleSelectorsFor: misspelled 
	"Answer an ordered collection of possible corrections
	for the misspelled selector in order of likelyhood"

	| numArgs candidates lookupString best binary short long first ss |
	lookupString _ misspelled asLowercase. "correct uppercase selectors to lowercase"
	numArgs _ lookupString numArgs.
	(numArgs < 0 or: [lookupString size < 2]) ifTrue: [^ OrderedCollection new: 0].
	first _ lookupString first.
	short _ lookupString size - (lookupString size // 4 max: 3) max: 2.
	long _ lookupString size + (lookupString size // 4 max: 3).

	"First assemble candidates for detailed scoring"
	candidates _ OrderedCollection new.
	self allMultiSymbolTablesDo: [:s | (((ss _ s size) >= short	"not too short"
			and: [ss <= long			"not too long"
					or: [(s at: 1) = first]])	"well, any length OK if starts w/same letter"
			and: [s numArgs = numArgs])	"and numArgs is the same"
			ifTrue: [candidates add: s]].

	"Then further prune these by correctAgainst:"
	best _ lookupString correctAgainst: candidates.
	((misspelled last ~~ $:) and: [misspelled size > 1]) ifTrue: [
		binary _ misspelled, ':'.		"try for missing colon"
		MultiSymbol hasInterned: binary ifTrue: [:him | best addFirst: him]].
	^ best