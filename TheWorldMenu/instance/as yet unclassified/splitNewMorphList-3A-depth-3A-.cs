splitNewMorphList: list depth: d

	| middle c prev next out |

	d <= 0 ifTrue:[^Array with: list].
	middle _ list size // 2 + 1.
	c _ (list at: middle) name first.
	prev _ middle - 1.
	[prev > 0 and:[(list at: prev) name first = c]] 
		whileTrue:[prev _ prev - 1].
	next _ middle + 1.
	[next <= list size and:[(list at: next) name first = c]]
		whileTrue:[next _ next + 1].
	"Choose the better cluster"
	(middle - prev) < (next - middle)
		ifTrue:[middle _ prev+1]
		ifFalse:[middle _ next].
	middle = 1 ifTrue:[middle _ next].
	middle >= list size ifTrue:[middle _ prev+1].
	(middle = 1 or:[middle >= list size]) ifTrue:[^Array with: list].
	out _ WriteStream on: Array new.
	out nextPutAll: (self splitNewMorphList: (list copyFrom: 1 to: middle-1) depth: d-1).
	out nextPutAll: (self splitNewMorphList: (list copyFrom: middle to: list size) depth: d-1).
	^out contents.