topClipValueFrom: last to: next
	^(last rasterPosY - last rasterPosW) /
		((next rasterPosW - last rasterPosW) - (next rasterPosY - last rasterPosY)).