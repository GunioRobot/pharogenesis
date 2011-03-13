directionFrom: p1 to: p2 | ex |

"This does 8 directions and is not used in current recognizer"
"get the bounding box"		ex _ p2 - p1. "unlike bmax-bmin, this can have negatives"

"Look for degenerate forms first: . - |"
"look for a dot"				ex abs < (3@3) ifTrue: [^' dot... '].
"look for hori line"			((ex y = 0) or: [(ex x/ex y) abs > 2]) ifTrue:
	"look for w-e"					[ex x > 0 ifTrue:[^' we-- ']
	"it's an e-w"						ifFalse:[^' ew-- ']].
"look for vertical line"		((ex x = 0) or: [(ex y/ex x) abs > 2]) ifTrue:
	"look for n-s"				[(ex y > 0) ifTrue:[ ^' ns||']
	"it's a s-n"						ifFalse:[^' sn|| ']].
"look for a diagonal"			(ex x/ex y) abs <= 2 ifTrue:
	"se or ne"					[ex x > 0 ifTrue:[ex y > 0 ifTrue:[^' se// ']. ^' ne// '].
	"sw or nw"									ex y > 0 ifTrue:[^' sw// ']. ^' nw// '].
