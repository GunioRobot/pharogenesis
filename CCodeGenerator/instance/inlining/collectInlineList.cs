collectInlineList
	"Make a list of methods that should be inlined."
	"Details: The method must not include any inline C, since the translator cannot currently map variable names in inlined C code. Methods to be inlined must be small or called from only one place."

	| methodsNotToInline callsOf inlineIt hasCCode nodeCount senderCount |
	methodsNotToInline _ Set new: methods size.

	"build dictionary to record the number of calls to each method"
	callsOf _ Dictionary new: methods size * 2.
	methods keys do: [ :sel | callsOf at: sel put: 0 ].

	"For each method, scan its parse tree once to:
		1. determine if the method contains C code or declarations
		2. determine how many nodes it has
		3. increment the sender counts of the methods it calls
		4. determine if it includes any C declarations or code"
	inlineList _ Set new: methods size * 2.
	methods do: [ :m |
		inlineIt _ #dontCare.
		(translationDict includesKey: m selector) ifTrue: [
			hasCCode _ true.
		] ifFalse: [
			hasCCode _ m declarations size > 0.
			nodeCount _ 0.
			m parseTree nodesDo: [ :node |
				node isSend ifTrue: [
					sel _ node selector.
					sel = #cCode: ifTrue: [ hasCCode _ true ].
					senderCount _ callsOf at: sel ifAbsent: [ nil ].
					nil = senderCount ifFalse: [
						callsOf at: sel put: senderCount + 1.
					].
				].
				nodeCount _ nodeCount + 1.
			].
			inlineIt _ m extractInlineDirective.  "may be true, false, or #dontCare"
		].
		(hasCCode or: [inlineIt = false]) ifTrue: [
			"don't inline if method has C code and is contains negative inline directive"
			methodsNotToInline add: m selector.
		] ifFalse: [
			((nodeCount < 40) or: [inlineIt = true]) ifTrue: [
				"inline if method has no C code and is either small or contains inline directive"
				inlineList add: m selector.
			].
		].
	].

	callsOf associationsDo: [ :assoc |
		((assoc value = 1) and: [(methodsNotToInline includes: assoc key) not]) ifTrue: [
			inlineList add: assoc key.
		].
	].