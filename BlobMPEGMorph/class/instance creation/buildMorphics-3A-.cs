buildMorphics: aFileName
	| primary child |

	primary _ (self basicNew quadNumber: 1) initialize.
	self remember: primary.
	primary initializePrimaryMpegPlayer: aFileName.
	primary openInWorld.
	2 to: 4 do: [:i | 
		child _ (self basicNew quadNumber: i) initialize.
		self remember: child.
		child initializeChildMpegPlayer: primary.
		child openInWorld].
	^primary
