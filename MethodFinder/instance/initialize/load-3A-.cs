load: dataWithAnswers
	"Find a function that takes the data and gives the answers.  Odd list entries are data for it, even ones are the answers. "
"  (MethodFinder new) load: #( (4 3) 7  (-10 5) -5  (-3 11) 8);
		findMessage  "

| fixed |
data _ Array new: dataWithAnswers size // 2.
1 to: data size do: [:ii | data at: ii put: (dataWithAnswers at: ii*2-1)].
answers _ Array new: data size.
1 to: answers size do: [:ii | answers at: ii put: (dataWithAnswers at: ii*2)].
fixed _ false.
data do: [:list | 
	(list isKindOf: SequenceableCollection) ifFalse: [
		^ self inform: 'first and third items are not Arrays'].
	list withIndexDo: [:arg :ind | 
			arg == #true ifTrue: [list at: ind put: true.  fixed _ true].
			arg == #false ifTrue: [list at: ind put: false.  fixed _ true].
			]].
answers withIndexDo: [:arg :ind | 
			arg == #true ifTrue: [answers at: ind put: true.  fixed _ true].
			arg == #false ifTrue: [answers at: ind put: false.  fixed _ true].
			].
fixed ifTrue: [self inform: '#(true false) are Symbols, not Booleans.  
Next time use { true. false }'].
argMap _ (1 to: data first size) asArray.
data do: [:list | list size = argMap size ifFalse: [
		self inform: 'data arrays must all be the same size']].
argMap size > 4 ifTrue: [self inform: 'No more than a receiver and 
three arguments allowed'].
	"Really only test receiver and three args." 
thisData _ data copy.
mapStage _ mapList _ nil.
