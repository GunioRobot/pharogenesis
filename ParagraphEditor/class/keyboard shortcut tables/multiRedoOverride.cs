multiRedoOverride
"Call this to set meta-r to perform the multilevel redo (or tweak the code below to have it bound to some other key sequence)."

"
ParagraphEditor multiRedoOverride.
"
	CmdActions at: $r asciiValue + 1 put: #multiRedo: 
