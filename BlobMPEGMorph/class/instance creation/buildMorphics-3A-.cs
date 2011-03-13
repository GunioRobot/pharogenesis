buildMorphics: aFileName
	| primary child |

	primary := (self basicNew quadNumber: 1) initialize.
	self remember: primary.
	primary initializePrimaryMpegPlayer: aFileName.
	primary openInWorld.
	2 to: 4 do: [:i | 
		child := (self basicNew quadNumber: i) initialize.
		self remember: child.
		child initializeChildMpegPlayer: primary.
		child openInWorld].
	^primary
