= aVertex
	^self class == aVertex class
		and:[self position = aVertex position
			and:[self normal = aVertex normal
				and:[self color = aVertex color
					and:[self texCoord = aVertex texCoord]]]]