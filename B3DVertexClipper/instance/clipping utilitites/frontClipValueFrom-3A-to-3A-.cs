frontClipValueFrom: last to: next
	^(last rasterPosZ + last rasterPosW) negated /
		((next rasterPosW - last rasterPosW) + (next rasterPosZ - last rasterPosZ)).