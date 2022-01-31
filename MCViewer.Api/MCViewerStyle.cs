using System.Runtime.Serialization;

namespace MCViewer.Api
{
    public enum MCViewerStyle
	{
		[EnumMember(Value = "2BA")]
		/// <summary>
		/// 2BA: Indicates that the MC-Viewer should use the UOB style sheet
		/// </summary>
		BBA,
		/// <summary>
		/// UOB/UOL: Indicates that the MC-Viewer should use the UOB/UOL style sheet
		/// </summary>
		[EnumMember(Value = "UOB")]
		UOL,
		// [EnumMember(Value = "InstallData")] Maybe we'll add InstallData in the future.
		// InstallData
	}
}
