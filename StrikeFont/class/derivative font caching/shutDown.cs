shutDown  "StrikeFont shutDown"
	"Deallocate synthetically derived copies of base fonts to save space"
	self allInstancesDo: [:sf | sf reset]