urlNoOverwrite: suggested
	"Look in the directory.  If there is a file of this name, create a new name.  Keep track of highest numbers used as a hint."

	| dir ll stem num local trial suffix |
	(suggested endsWith: '.sp') ifTrue: [suffix _ '.sp'].
	(suggested endsWith: '.bo') ifTrue: [suffix _ '.bo'].
	suffix ifNil: [self error: 'unknown suffix'].
	dir _ ServerFile new fullPath: suggested.
	(dir includesKey: dir fileName) ifFalse: [^ url _ suggested].
	"File already exists!  Create a new name"
	"Find the stem file name"
	stem _ SqueakPage stemUrl: suggested.
	num _ stem = RecentStem ifTrue: [RecentMaxNum+1] ifFalse: [1].

	local _ dir fileName.	"ugh, take stem again..."
	ll _ local findLast: [:char | char == $.].
	ll = 0 ifFalse: [local _ local copyFrom: 1 to: ll-1].	"remove .sp"
	local _ (local splitInteger) at: 1.		"remove trailing number"
	local last == $x ifFalse: [local _ local , 'x'].
	[trial _ local, num printString, suffix.
		dir includesKey: trial] whileTrue: [num _ num + 1].
	RecentStem _ stem.  RecentMaxNum _ num.
	^ url _ stem, 'x', num printString, suffix