allUnSentMessages   "Smalltalk allUnSentMessages"
	"Answer the set of selectors that are implemented by some object
	in the system but not sent by any."
	| sent unsent |
	sent _ self allSentMessages.
	unsent _ Set new.
	self allImplementedMessages do:
		[:sel | (sent includes: sel) ifFalse: [unsent add: sel]].
	^ unsent
"
 | f cl lastClass |
f _ FileStream newFileNamed: 'UnsentMessages.txt'.
lastClass _ 'xx'.
methods _ SortedCollection new.
Smalltalk allUnSentMessages do:
	[:sel | methods addAll: (Smalltalk allImplementorsOf: sel)].
methods do:
	[:m | cl _ m copyUpTo: $ . 
	cl = lastClass
		ifTrue: [f nextPutAll: (m copyFrom: lastClass size+1 to: m size)]
		ifFalse: [f cr; cr; nextPutAll: m.  lastClass _ cl]].
f close.
"