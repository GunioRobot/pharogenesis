deleteReleases
	"Delete my releases."

	releases copy do: [:release | release delete]