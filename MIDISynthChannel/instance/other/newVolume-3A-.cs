newVolume: valueByte
	"Set the channel volume to the level given by the given number in the range 0..127."

	| snd newVolume |
	channelVolume _ valueByte asFloat / 127.0.
	newVolume _ masterVolume * channelVolume.
	activeSounds do: [:entry |
		snd _ entry at: 2.
		snd adjustVolumeTo: newVolume overMSecs: 10].
