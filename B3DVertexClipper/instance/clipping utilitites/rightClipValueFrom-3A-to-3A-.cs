rightClipValueFrom: last to: next
	^(last rasterPosX - last rasterPosW) /
		((next rasterPosW - last rasterPosW) - (next rasterPosX - last rasterPosX)).