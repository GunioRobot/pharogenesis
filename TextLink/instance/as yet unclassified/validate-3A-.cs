validate: specString
	"Can this string be decoded to be Class space Method (or Comment, Definition, Hierarchy)? If so, return it in valid format, else nil" 

	| list first mid last |
	list _ specString findTokens: ' 	.|'.
	list size > 3 ifTrue: [^ nil].
	list size < 2 ifTrue: [^ nil].
	Symbol hasInterned: list first ifTrue: [:sym | first _ sym].
	first ifNil: [^ nil].
	Smalltalk at: first ifAbsent: [^ nil].
	mid _ list size = 3 
		ifTrue: [(list at: 2) = 'class' ifTrue: ['class '] ifFalse: [^ nil]]
		ifFalse: [''].
	"OK if method name is not interned -- may not be defined yet"
	last _ list last.
	last first isUppercase ifTrue: [
		(#('Comment' 'Definition' 'Hierarchy') includes: last) ifFalse: [^ nil]].
	^ first, ' ', mid, last