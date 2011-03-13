laySubpartsOutInOneRow
	| aPosition |
	aPosition _ padding @ padding.
	submorphs do:
	[:aMorph |
		aMorph position: (aPosition + (padding @ 0)).
		aPosition _ aMorph topRight]