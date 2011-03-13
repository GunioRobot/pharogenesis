stepDown: evt with: aMorph
	self stopRunningScripts.
	self playfield borderColor: EToyParameters runningPlayfieldBorderColor; changed