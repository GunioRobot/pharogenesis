topClipValueFrom: last to: next
	self returnTypeC:'double'.
	^(((self cCoerce: last to: 'float *') at: PrimVtxRasterPosY) - 
		((self cCoerce: last to:'float *') at: PrimVtxRasterPosW)) /

	(
	(((self cCoerce: next to:'float *') at: PrimVtxRasterPosW) -
		((self cCoerce: last to: 'float *') at: PrimVtxRasterPosW))
	-
	 (((self cCoerce: next to:'float *') at: PrimVtxRasterPosY) -
		((self cCoerce: last to:'float *') at: PrimVtxRasterPosY))
	).