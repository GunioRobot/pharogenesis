backClipValueFrom: last to: next
	self returnTypeC:'double'.
	^(((self cCoerce: last to: 'float *') at: PrimVtxRasterPosZ) - 
		((self cCoerce: last to:'float *') at: PrimVtxRasterPosW)) /

	(
	(((self cCoerce: next to:'float *') at: PrimVtxRasterPosW) -
		((self cCoerce: last to: 'float *') at: PrimVtxRasterPosW))
	-
	 (((self cCoerce: next to:'float *') at: PrimVtxRasterPosZ) -
		((self cCoerce: last to:'float *') at: PrimVtxRasterPosZ))
	).