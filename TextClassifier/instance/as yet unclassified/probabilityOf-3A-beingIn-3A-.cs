probabilityOf: msg beingIn: categoryName
	| sortedProbabilities p product prodInv pSpam yesSize noSize no yes |
	sortedProbabilities _ SortedCollection sortBlock: [:a :b | (a - 0.5) abs >= (b - 0.5) abs].
	categorizer categoryNamed: categoryName andOppositeDo: [:yesTokens :noTokens |
		yesSize _ yesTokens size.
		noSize _ noTokens size.
		msg tokens do:
			[:t |
			no _ [(noTokens occurrencesOf: t) asFloat / noSize] on: ZeroDivide do: [:e | e return: 0.0].
			yes _ [(yesTokens occurrencesOf: t) asFloat / yesSize] on: ZeroDivide do: [:e | e return: 0.0].
			p _ (([yes / (yes + no)] on: ZeroDivide do: [:e | e return: 0.2]) max: 0.01) min: 0.99.
			sortedProbabilities add: p].
		sortedProbabilities _ sortedProbabilities first: 15.
		product _ sortedProbabilities inject: 1.0 into: [:i :n | i*n].
		prodInv _ sortedProbabilities inject: 1.0 into: [:i :n | i * (1.0 - n)].
		pSpam _ product / (product + prodInv).
	].
	^ pSpam

