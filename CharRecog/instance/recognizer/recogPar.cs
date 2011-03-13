recogPar | prv cdir result features char r s t dir |

"Inits"				(p _ Pen new) defaultNib: 1; down.
	"for points"		pts _ ReadWriteStream on: #().

"Event Loop"	
		[Sensor anyButtonPressed] whileFalse: [(Sensor mousePoint x < 50) ifTrue: [^''].].

"First-Time"			pts reset.		
"will hold features"		ftrs _ ''.

					  (Sensor anyButtonPressed) ifTrue:
						[pts nextPut: (bmin _ bmax _ t _ s _ sts _ Sensor mousePoint).
						p place: sts. cdir _ nil.

"Each-Time"		[Sensor anyButtonPressed] whileTrue:
						[
"ink raw input"			p goto: (r _ Sensor mousePoint).
"smooth it"				s _ (0.5*s) + (0.5*r).
"thin the stream"		((s x - t x) abs > 3 or:[(s y - t y) abs > 3]) ifTrue:
							[ pts nextPut: t. 
"bounding box"			bmin _ bmin min: s. bmax _ bmax max: s.
"get current dir"				dir _ (self fourDirsFrom: t to: s). t _ s.
							dir ~= ' dot... ' ifTrue: [
"store new dirs"					cdir ~= dir ifTrue: [ftrs _ ftrs, (cdir _ dir)]].
"for inked t's" 			p place: t; go: 1; place: r.
							].
 "End Each-Time Loop"	].

"Last-Time"	
"start a new recog for next point"	[CharRecog new recognize] fork.

"save last points"		pts nextPut: t; nextPut: r.
"find rest of features"	features _ self extractFeatures.
"find char..."			char _ CharacterDictionary at: features ifAbsent:
"...or get from user"			[ result _ FillInTheBlank request:
							 'Not recognized. type char, or type ~: ', features.
"ignore or..."				result = '~' ifTrue: ['']
"...enter new char"			ifFalse: [CharacterDictionary at: features put: result. result]].

"control the editor"		(char = 'cr' ifTrue: [Transcript cr] ifFalse:
						[char = 'bs' ifTrue: [Transcript bs] ifFalse:
						[char = 'tab' ifTrue:[Transcript tab] ifFalse:
						[Transcript show: char]]]). 

"End First-Time Loop"	]. 



			   
 