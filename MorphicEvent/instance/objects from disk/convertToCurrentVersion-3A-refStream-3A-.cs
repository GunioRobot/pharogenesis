convertToCurrentVersion: varDict refStream: smartRefStrm
	
	| answer |

	"ar 10/25/2000: This method is used to convert OLD MorphicEvents into new ones."
	varDict at: 'cursorPoint' ifPresent: [ :x | 
		answer _ self convertOctober2000: varDict using: smartRefStrm.
		varDict removeKey: 'cursorPoint'.	"avoid doing this again"
		^answer
	].
	^super convertToCurrentVersion: varDict refStream: smartRefStrm.


