forward: dist
	"Move the given distance in the direction of my heading."

	1 to: dist do: [:i | self forwardOne].
