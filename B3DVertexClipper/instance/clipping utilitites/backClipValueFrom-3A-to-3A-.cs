backClipValueFrom: last to: next
	^(last rasterPosZ - last rasterPosW) /
		((next rasterPosW - last rasterPosW) - (next rasterPosZ - last rasterPosZ)).