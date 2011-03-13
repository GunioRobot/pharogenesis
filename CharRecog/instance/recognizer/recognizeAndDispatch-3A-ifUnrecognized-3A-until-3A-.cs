recognizeAndDispatch: charDispatchBlock ifUnrecognized: unrecognizedFeaturesBlock until: terminationBlock
	"Recognize characters, and dispatch each one found by evaluating charDispatchBlock; proceed until terminationBlock is true.  This method derives directly from Alan's 1/96 #recognize method, but factors out the character dispatch and the termination condition from the main body of the method.  2/2/96 sw.   2/5/96 sw: switch to using a class variable for the character dictionary, and don't put vacuous entries in the dictionary if the user gives an empty response to the prompt, and don't send empty characters onward, and use a variant of the FillInTheBlank that keeps the prompt clear of the working window.  8/17/96 tk: Turn cr, tab, bs into strings so they work.
	 9/18/96 sw: in this variant, the block for handling unrecognized features is handed in as an argument, so that in some circumstances we can avoid putting up a prompt.  unrecognizedFeaturesBlock should be a one-argument block, which is handed in the features and which is expected to return a string which indicates the determined translation -- empty if none."

	| prv cdir features char r s t dir |

"Inits"				(p _ Pen new) defaultNib: 1; down.
	"for points"		pts _ ReadWriteStream on: #().

"Event Loop"	
					[terminationBlock value] whileFalse:

"First-Time"			[pts reset.		
"will hold features"		ftrs _ ''.

					  (Sensor anyButtonPressed) ifTrue:
						[pts nextPut: (bmin _ bmax _ t _ s _ sts _ Sensor mousePoint).
						p place: sts. cdir _ nil.

"Each-Time"		[Sensor anyButtonPressed] whileTrue:
"ink raw input"			[p goto: (r _ Sensor mousePoint).
"smooth it"				s _ (0.5*s) + (0.5*r).
"thin the stream"		((s x - t x) abs > 3 or:[(s y - t y) abs > 3]) ifTrue:
							[pts nextPut: t. 
"bounding box"				bmin _ bmin min: s. bmax _ bmax max: s.
"get current dir"				dir _ (self fourDirsFrom: t to: s). t _ s.
							dir ~= ' dot... ' ifTrue:
"store new dirs"					[cdir ~= dir ifTrue: [ftrs _ ftrs, (cdir _ dir)]].
"for inked t's" 				p place: t; go: 1; place: r]].
 "End Each-Time Loop"

"Last-Time"	
"save last points"		pts nextPut: t; nextPut: r.
"find rest of features"	features _ self extractFeatures.
"find char..."			char _ CharacterDictionary at: features ifAbsent:
							[unrecognizedFeaturesBlock value: features].

"special chars"		char size > 0 ifTrue:
						[char = 'tab' ifTrue: [char _ Tab].
						char = 'cr' ifTrue:	[char _ CR].
"must be a string"		char class == Character ifTrue: 
							[char _ String with: char].
						char = 'bs' ifTrue:	[char _ BS].
"control the editor"		charDispatchBlock value: char]]]
 