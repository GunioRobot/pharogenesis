laySubpartsOutInOneRow
	| aPosition |
	aPosition _ 0 @ padding.
	submorphs do:
	[:aMorph |
		aMorph position: (aPosition + (padding @ 0)).
		aPosition _ aMorph topRight]