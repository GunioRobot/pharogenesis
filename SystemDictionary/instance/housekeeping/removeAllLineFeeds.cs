removeAllLineFeeds    "Smalltalk removeAllLineFeeds"
	"Scan all methods for source code with lineFeeds.
	Replaces all occurrences of <CR><LF> by <CR>, noted by beep.
	Halts with a message if any other LFs are found."
	 | oldCodeString n crlf cr newCodeString oldStamp oldCategory m |
	crlf _ String with: Character cr with: Character lf.
	cr _ String with: Character cr.
	Smalltalk forgetDoIts.
'Scanning sources for LineFeeds.
This will take a few minutes...'
displayProgressAt: Sensor cursorPoint
from: 0 to: CompiledMethod instanceCount
during: [:bar | n _ 0. m _ 0.
	Smalltalk allBehaviorsDo:
		[:cls | 
		cls selectors do:
			[:selector | (n _ n+1) \\ 100 = 0 ifTrue: [bar value: n].
			oldCodeString _ (cls sourceCodeAt: selector) asString.
			(oldCodeString indexOf: Character lf startingAt: 1) > 0 ifTrue:
				[self beep.
				newCodeString _ oldCodeString copyReplaceAll: crlf with: cr asTokens: false.
				(newCodeString indexOf: Character lf startingAt: 1) > 0
					ifTrue: [(self confirm: cls name , ' ' , (selector contractTo: 30) , '
has an isolated LineFeed (not part of CRLF).
Shall I replace it?') ifFalse: [self halt]].
				oldStamp _ Utilities timeStampForMethod: (cls compiledMethodAt: selector).
				oldCategory _ cls whichCategoryIncludesSelector: selector.
				cls compile: newCodeString classified: oldCategory withStamp: oldStamp notifying: nil.
				m _ m + 1]]].
].
	Transcript cr; show: m printString , ' methods stripped of LFs.'.
