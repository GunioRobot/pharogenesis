compareTiming
"
MultiSymbol compareTiming
"
	| answer t selectorList implementorLists flattenedList md |

	answer _ WriteStream on: String new.
	SmalltalkImage current timeStamp: answer.
	answer cr; cr.
	answer nextPutAll: MethodDictionary instanceCount printString,' method dictionaries'; cr; cr.
	answer nextPutAll: (
		MethodDictionary allInstances inject: 0 into: [ :sum :each | sum + each size]) printString,
		' method dictionary entries'; cr; cr.

	md _ MethodDictionary allInstances.
	t _ [100 timesRepeat: [md do: [ :each | each includesKey: #majorShrink]]] timeToRun.
	answer nextPutAll: t printString,
		' ms to check all method dictionaries for #majorShrink 1000 times'; cr; cr.

	selectorList _ MultiSymbol selectorsContaining: 'help'.
	t _ [
		3 timesRepeat: [selectorList collect: [:each | SystemNavigation default allImplementorsOf: each]]
	] timeToRun.
	answer nextPutAll: t printString,' ms to do #allImplementorsOf: for ',
		selectorList size printString,' selectors like *help* 3 times'; cr; cr.

	t _ [
		3 timesRepeat: [
			selectorList do: [:eachSel | md do: [ :eachMd | eachMd includesKey: eachSel]]
		]
	] timeToRun.
	answer nextPutAll: t printString,' ms to do #includesKey: for ',
		md size printString,' methodDicts for ',
		selectorList size printString,' selectors like *help* 3 times'; cr; cr.

	#('help' 'majorShrink') do: [ :substr |
		answer nextPutAll: (MultiSymbol selectorsContaining: substr) size printString,
				' selectors containing "',substr,'"'; cr.

		t _ [
			3 timesRepeat: [
				selectorList _ MultiSymbol selectorsContaining: substr.
			].
		] timeToRun.
		answer nextPutAll: t printString,' ms to find MultiSymbols containing *',substr,'* 3 times'; cr.

		t _ [
			3 timesRepeat: [
				selectorList _ MultiSymbol selectorsContaining: substr.
				implementorLists _ selectorList collect: [:each | Smalltalk allImplementorsOf: each].
				flattenedList _ SortedCollection new.
				implementorLists do: [:each | flattenedList addAll: each].
			].
		] timeToRun.
		answer nextPutAll: t printString,' ms to find implementors of *',substr,'* 3 times'; cr; cr.
	].
	StringHolder new contents: answer contents; openLabel: 'timing'.
