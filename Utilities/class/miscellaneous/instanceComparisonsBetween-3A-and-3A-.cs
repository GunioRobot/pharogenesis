instanceComparisonsBetween: fileName1 and: fileName2
	"For differential results, run printSpaceAnalysis twice with different fileNames,
	then run this method...
		Smalltalk printSpaceAnalysis: 0 on: 'STspace.text1'.
			--- do something that uses space here ---
		Smalltalk printSpaceAnalysis: 0 on: 'STspace.text2'.
		Smalltalk instanceComparisonsBetween: 'STspace.text1' and 'STspace.text2'"

	| instCountDict report f aString items className newInstCount oldInstCount newSpace oldPair oldSpace |
	instCountDict _ Dictionary new.
	report _ ReadWriteStream on: ''.
	f _ FileStream oldFileNamed: fileName1.
	[f atEnd] whileFalse:
		[aString _ f upTo: Character cr.
		items _ aString findTokens: ' '.
		(items size == 4 or: [items size == 5]) ifTrue:
			[instCountDict at: items first put: (Array with: items third asNumber with: items fourth asNumber)]].
	f close.

	f _ FileStream oldFileNamed: fileName2.
	[f atEnd] whileFalse:
		[aString _ f upTo: Character cr.
		items _ aString findTokens: ' '.
		(items size == 4 or: [items size == 5]) ifTrue:
			[className _ items first.
			newInstCount _ items third asNumber.
			newSpace _ items fourth asNumber.
			oldPair _ instCountDict at: className ifAbsent: [nil].
			oldInstCount _ oldPair ifNil: [0] ifNotNil: [oldPair first].
			oldSpace _ oldPair ifNil: [0] ifNotNil: [oldPair second].
			oldInstCount ~= newInstCount ifTrue:
				[report nextPutAll: (newInstCount - oldInstCount) printString; tab; nextPutAll: (newSpace - oldSpace) printString; tab; nextPutAll: className asString; cr]]].
	f close.

	(StringHolder new contents: report contents)
		openLabel: 'Instance count differentials between ', fileName1, ' and ', fileName2