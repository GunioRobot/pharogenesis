bigMan
	"
	Speaker bigMan say: 'I am the child? No. I am the big man speaking.'
	"

	^ self new
		pitch: 90.0;
		range: 0.5;
		voice: (KlattVoice new tract: 20)