do: aBlock toFieldNumber: aNumber
	"Considering the receiver as a holder of tab-delimited fields, evaluate aBlock on behalf of a field in this string"

	| start end index |
	start _ 1.
	index _ 1.
	[start <= self size] whileTrue: 
		[end _ self indexOf: Character tab startingAt: start ifAbsent: [self size + 1].
		end _ end - 1.
		aNumber = index ifTrue:
			[aBlock value: (self copyFrom: start  to: end).
			^ self].
		index _ index + 1.
		start _ end + 2]

"
1 to: 6 do:
	[:aNumber |
		'fred	charlie	elmo		wimpy	friml' do:
			[:aField | Transcript cr; show: aField] toFieldNumber: aNumber]
"