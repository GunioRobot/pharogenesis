newCompressedSoundFrom: dataStream

	| samplingRate |

	samplingRate _ (dataStream upTo: 0 asCharacter) asNumber.
	^CompressedSoundData new 
		withEToySound: dataStream upToEnd
		samplingRate: samplingRate.
