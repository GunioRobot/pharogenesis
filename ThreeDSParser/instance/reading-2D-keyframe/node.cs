node
	"Subchunk of keyframeData"
	
	| nodeData |
	nodeData := Dictionary new.
	self recognize: #(
		(16rB030 short id)
		(16rB010 nodeHeader header)
		(16rB011 cString instanceName)
		(16rB013 vector3 pivot)
		(16rB014 twoVector3 boundingBox)
		(16rB015 float smoothAngle)
		(16rB020 trackVector positionTrack)
		(16rB021 trackRotation rotationTrack)
		(16rB022 trackVector scaleTrack)
		(16rB023 trackFloat fovTrack)
		(16rB024 trackFloat rollTrack)
		(16rB025 trackColor colorTrack)
		(16rB026 trackCString morphTrack)
		(16rB027 trackFloat hotspotTrack)
		(16rB028 trackFloat falloffTrack)
		(16rB029 trackFlag hideTrack)
		) do: [:item |
			item key == #header 
				ifTrue: [nodeData addAll: item value]
				ifFalse: [nodeData add: item].
			log == nil ifFalse: [(#(id pivot boundingBox instanceName) includes: item key) ifTrue: [
				log crtab: indent+1; print: item value]]].
	^(nodeData at: #id ifAbsent:[^nil]) -> nodeData