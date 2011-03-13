obsoleteIndexedPrimitiveTable
	"Interpreter obsoleteIndexedPrimitiveTableString"
	"Initialize the links from the (now obsolete) indexed primitives to
	the new named primitives."
	| table |
	table _ Array new: MaxPrimitiveIndex+1.
	#(
		(96	(BitBltPlugin primitiveCopyBits))
		(104 (BitBltPlugin primitiveDrawLoop))
		(147 (BitBltPlugin primitiveWarpBits))

		(146 (JoystickTabletPlugin primitiveReadJoystick))

		"File Primitives (150-169)"
		(150 (FilePlugin primitiveFileAtEnd))
		(151 (FilePlugin primitiveFileClose))
		(152 (FilePlugin primitiveFileGetPosition))
		(153 (FilePlugin primitiveFileOpen))
		(154 (FilePlugin primitiveFileRead))
		(155 (FilePlugin primitiveFileSetPosition))
		(156 (FilePlugin primitiveFileDelete))
		(157 (FilePlugin primitiveFileSize))
		(158 (FilePlugin primitiveFileWrite))
		(159 (FilePlugin primitiveFileRename))
		(160 (FilePlugin primitiveDirectoryCreate))
		(161 (FilePlugin primitiveDirectoryDelimitor))
		(162 (FilePlugin primitiveDirectoryLookup))
		(163 (FilePlugin primitiveDirectoryDelete))
		(164 (FilePlugin primitiveDirectoryGetMacTypeAndCreator))
		(169 (FilePlugin primitiveDirectorySetMacTypeAndCreator))

		"Sound Primitives (170-199)"
		(170 (SoundPlugin primitiveSoundStart))
		(171 (SoundPlugin primitiveSoundStartWithSemaphore))
		(172 (SoundPlugin primitiveSoundStop))
		(173 (SoundPlugin primitiveSoundAvailableSpace))
		(174 (SoundPlugin primitiveSoundPlaySamples))
		(175 (SoundPlugin primitiveSoundPlaySilence))

		(176 (SoundGenerationPlugin primitiveWaveTableSoundMix))
		(177 (SoundGenerationPlugin primitiveFMSoundMix))
		(178 (SoundGenerationPlugin primitivePluckedSoundMix))
		(179 (SoundGenerationPlugin primitiveSampledSoundMix))
		(180 (SoundGenerationPlugin primitiveMixFMSound))
		(181 (SoundGenerationPlugin primitiveMixPluckedSound))
		(182 (SoundGenerationPlugin primitiveOldSampledSoundMix))
		(183 (SoundGenerationPlugin primitiveApplyReverb))
		(184 (SoundGenerationPlugin primitiveMixLoopedSampledSound))
		(185 (SoundGenerationPlugin primitiveMixSampledSound))

		(189 (SoundPlugin primitiveSoundInsertSamples))
		(190 (SoundPlugin primitiveSoundStartRecording))
		(191 (SoundPlugin primitiveSoundStopRecording))
		(192 (SoundPlugin primitiveSoundGetRecordingSampleRate))
		(193 (SoundPlugin primitiveSoundRecordSamples))
		(194 (SoundPlugin primitiveSoundSetRecordLevel))

		"Networking Primitives (200-229)"
		(200 (SocketPlugin primitiveInitializeNetwork))
		(201 (SocketPlugin primitiveResolverStartNameLookup))
		(202 (SocketPlugin primitiveResolverNameLookupResult))
		(203 (SocketPlugin primitiveResolverStartAddressLookup))
		(204 (SocketPlugin primitiveResolverAddressLookupResult))
		(205 (SocketPlugin primitiveResolverAbortLookup))
		(206 (SocketPlugin primitiveResolverLocalAddress))
		(207 (SocketPlugin primitiveResolverStatus))
		(208 (SocketPlugin primitiveResolverError))
		(209 (SocketPlugin primitiveSocketCreate))
		(210 (SocketPlugin primitiveSocketDestroy))
		(211 (SocketPlugin primitiveSocketConnectionStatus))
		(212 (SocketPlugin primitiveSocketError))
		(213 (SocketPlugin primitiveSocketLocalAddress))
		(214 (SocketPlugin primitiveSocketLocalPort))
		(215 (SocketPlugin primitiveSocketRemoteAddress))
		(216 (SocketPlugin primitiveSocketRemotePort))
		(217 (SocketPlugin primitiveSocketConnectToPort))
		(218 (SocketPlugin primitiveSocketListenWithOrWithoutBacklog))
		(219 (SocketPlugin primitiveSocketCloseConnection))
		(220 (SocketPlugin primitiveSocketAbortConnection))
		(221 (SocketPlugin primitiveSocketReceiveDataBufCount))
		(222 (SocketPlugin primitiveSocketReceiveDataAvailable))
		(223 (SocketPlugin primitiveSocketSendDataBufCount))
		(224 (SocketPlugin primitiveSocketSendDone))
		(225 (SocketPlugin primitiveSocketAccept))

		"Other Primitives (230-249)"
		(234 (MiscPrimitivePlugin primitiveDecompressFromByteArray))
		(235 (MiscPrimitivePlugin primitiveCompareString))
		(236 (MiscPrimitivePlugin primitiveConvert8BitSigned))
		(237 (MiscPrimitivePlugin primitiveCompressToByteArray))
		(238 (SerialPlugin primitiveSerialPortOpen))
		(239 (SerialPlugin primitiveSerialPortClose))
		(240 (SerialPlugin primitiveSerialPortWrite))
		(241 (SerialPlugin primitiveSerialPortRead))

		(243 (MiscPrimitivePlugin primitiveTranslateStringWithTable))
		(244 (MiscPrimitivePlugin primitiveFindFirstInString))
		(245 (MiscPrimitivePlugin primitiveIndexOfAsciiInString))
		(246 (MiscPrimitivePlugin primitiveFindSubstring))

		"MIDI Primitives (520-539)"
		(521 (MIDIPlugin primitiveMIDIClosePort))
		(522 (MIDIPlugin primitiveMIDIGetClock))
		(523 (MIDIPlugin primitiveMIDIGetPortCount))
		(524 (MIDIPlugin primitiveMIDIGetPortDirectionality))
		(525 (MIDIPlugin primitiveMIDIGetPortName))
		(526 (MIDIPlugin primitiveMIDIOpenPort))
		(527 (MIDIPlugin primitiveMIDIParameterGetOrSet))
		(528 (MIDIPlugin primitiveMIDIRead))
		(529 (MIDIPlugin primitiveMIDIWrite))

		"Experimental Asynchrous File Primitives"
		(540 (AsynchFilePlugin primitiveAsyncFileClose))
		(541 (AsynchFilePlugin primitiveAsyncFileOpen))
		(542 (AsynchFilePlugin primitiveAsyncFileReadResult))
		(543 (AsynchFilePlugin primitiveAsyncFileReadStart))
		(544 (AsynchFilePlugin primitiveAsyncFileWriteResult))
		(545 (AsynchFilePlugin primitiveAsyncFileWriteStart))

		"Pen Tablet Primitives"
		(548 (JoystickTabletPlugin primitiveGetTabletParameters))
		(549 (JoystickTabletPlugin primitiveReadTablet))

		"Sound Codec Primitives"

		(550 (ADPCMCodecPlugin primitiveDecodeMono))
		(551 (ADPCMCodecPlugin primitiveDecodeStereo))	
		(552 (ADPCMCodecPlugin primitiveEncodeMono))	
		(553 (ADPCMCodecPlugin primitiveEncodeStereo))

	) do:[:spec| table at: spec first+1 put: spec second].
	^table