leftClipValueFrom: last to: next
	^(last rasterPosX + last rasterPosW) negated /
		((next rasterPosW - last rasterPosW) + (next rasterPosX - last rasterPosX)).