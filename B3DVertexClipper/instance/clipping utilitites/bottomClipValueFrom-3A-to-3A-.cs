bottomClipValueFrom: last to: next
	^(last rasterPosY + last rasterPosW) negated /
		((next rasterPosW - last rasterPosW) + (next rasterPosY - last rasterPosY)).