findMatch: here lastLength: lastLength lastMatch: lastMatch chainLength: maxChainLength goodMatch: goodMatch
	"Find the longest match for the string starting at here.
	If there is no match longer than lastLength return lastMatch/lastLength.
	Traverse at most maxChainLength entries in the hash table.
	Stop if a match of at least goodMatch size has been found."
	| matchResult matchPos distance chainLength limit bestLength length |
	self inline: false.
	"Compute the default match result"
	matchResult _ (lastLength bitShift: 16) bitOr: lastMatch.

	"There is no way to find a better match than MaxMatch"
	lastLength >= DeflateMaxMatch ifTrue:[^matchResult].

	"Start position for searches"
	matchPos _ zipHashHead at: (self updateHashAt: here + DeflateMinMatch - 1).

	"Compute the distance to the (possible) match"
	distance _ here - matchPos.

	"Note: It is required that 0 < distance < MaxDistance"
	(distance > 0 and:[distance < DeflateMaxDistance]) ifFalse:[^matchResult].

	chainLength _ maxChainLength.	"Max. nr of match chain to search"
	here > DeflateMaxDistance	"Limit for matches that are too old"
		ifTrue:[limit _ here - DeflateMaxDistance]
		ifFalse:[limit _ 0].

	"Best match length so far (current match must be larger to take effect)"
	bestLength _ lastLength.

	[true] whileTrue:[
		"Compare the current string with the string at match position"
		length _ self compare: here with: matchPos min: bestLength.
		"Truncate accidental matches beyound stream position"
		(here + length > zipPosition) ifTrue:[length _ zipPosition - here].
		"Ignore very small matches if they are too far away"
		(length = DeflateMinMatch and:[(here - matchPos) > (DeflateMaxDistance // 4)])
			ifTrue:[length _ DeflateMinMatch - 1].
		length > bestLength ifTrue:["We have a new (better) match than before"
			"Compute the new match result"
			matchResult _ (length bitShift: 16) bitOr: matchPos.
			bestLength _ length.
			"There is no way to find a better match than MaxMatch"
			bestLength >= DeflateMaxMatch ifTrue:[^matchResult].
			"But we may have a good, fast match"
			bestLength > goodMatch ifTrue:[^matchResult].
		].
		(chainLength _ chainLength - 1) > 0 ifFalse:[^matchResult].
		"Compare with previous entry in hash chain"
		matchPos _ zipHashTail at: (matchPos bitAnd: DeflateWindowMask).
		matchPos <= limit ifTrue:[^matchResult]. "Match position is too old"
	].