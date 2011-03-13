showHideSoundTrack

	soundTrackForm ifNotNil:
		[soundTrackMorph delete.
		^ soundTrackForm _ soundTrackMorph _ nil].

	soundTrackForm _ scorePlayer volumeForm: 20 from: 1 to: scorePlayer samples size nSamplesPerPixel: 250.
	soundTrackMorph _ ImageMorph new image: (Form extent: 140 @ soundTrackForm height).
	soundTrackMorph addMorph:
		(Morph newBounds: (soundTrackMorph bounds topCenter extent: 1@soundTrackMorph height)
					color: Color red).
	self addMorph: soundTrackMorph after: currentPage.
	self layoutChanged.
	self stepSoundTrack.
