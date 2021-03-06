﻿using System;
using System.Collections.Generic;
using uTinyRipper.AssetExporters;
using uTinyRipper.YAML;
using uTinyRipper.SerializedFiles;

namespace uTinyRipper.Classes.LightmapSettingss
{
	public struct LightmapEditorSettings
	{
		public LightmapEditorSettings(bool _)
		{
			Resolution = 2.0f;
			BakeResolution = 40.0f;
			TextureWidth = 1024;
			TextureHeight = 1024;
			AO = false;
			AOMaxDistance = 1.0f;
			CompAOExponent = 1.0f;
			CompAOExponentDirect = 0.0f;
			Padding = 2;
			LightmapParameters = default;
			LightmapsBakeMode = 1;
			TextureCompression = true;
			FinalGather = false;
			FinalGatherFiltering = true;
			FinalGatherRayCount = 256;
			ReflectionCompression = 2;
			MixedBakeMode = 2;
			BakeBackend = 0;
			PVRSampling = 1;
			PVRDirectSampleCount = 32;
			PVRSampleCount = 500;
			PVRBounces = 2;
			PVRFilterTypeDirect = 0;
			PVRFilterTypeIndirect = 0;
			PVRFilterTypeAO = 0;
			PVRFilteringMode = 1;
			PVRCulling = true;
			PVRFilteringGaussRadiusDirect = 1;
			PVRFilteringGaussRadiusIndirect = 5;
			PVRFilteringGaussRadiusAO = 2;
			PVRFilteringAtrousPositionSigmaDirect = 0.5f;
			PVRFilteringAtrousPositionSigmaIndirect = 2.0f;
			PVRFilteringAtrousPositionSigmaAO = 1.0f;
			ShowResolutionOverlay = true;
		}

		private static int GetSerializedVersion(Version version)
		{
			if (Config.IsExportTopmostSerializedVersion)
			{
				return 9;
			}

			/*if (version.IsGreaterEqual())
			{
				return 9;
			}
			if (version.IsGreaterEqual())
			{
				return 8;
			}
			if (version.IsGreaterEqual())
			{
				return 7;
			}
			if (version.IsGreaterEqual())
			{
				return 6;
			}
			if (version.IsGreaterEqual())
			{
				return 5;
			}
			if (version.IsGreaterEqual())
			{
				return 4;
			}
			if (version.IsGreaterEqual())
			{
				return 3;
			}
			if (version.IsGreaterEqual())
			{
				return 2;
			}
			return 1;*/
			throw new NotImplementedException();
		}


		public void Read(AssetReader reader)
		{
			Resolution = reader.ReadSingle();
			BakeResolution = reader.ReadSingle();
			TextureWidth = reader.ReadInt32();
			TextureHeight = reader.ReadInt32();
			AO = reader.ReadBoolean();
			reader.AlignStream(AlignType.Align4);

			AOMaxDistance = reader.ReadSingle();
			CompAOExponent = reader.ReadSingle();
			CompAOExponentDirect = reader.ReadSingle();
			Padding = reader.ReadInt32();
			LightmapParameters.Read(reader);
			LightmapsBakeMode = reader.ReadInt32();
			TextureCompression = reader.ReadBoolean();
			FinalGather = reader.ReadBoolean();
			FinalGatherFiltering = reader.ReadBoolean();
			reader.AlignStream(AlignType.Align4);

			FinalGatherRayCount = reader.ReadInt32();
			ReflectionCompression = reader.ReadInt32();
			MixedBakeMode = reader.ReadInt32();
			BakeBackend = reader.ReadInt32();
			PVRSampling = reader.ReadInt32();
			PVRDirectSampleCount = reader.ReadInt32();
			PVRSampleCount = reader.ReadInt32();
			PVRBounces = reader.ReadInt32();
			PVRFilterTypeDirect = reader.ReadInt32();
			PVRFilterTypeIndirect = reader.ReadInt32();
			PVRFilterTypeAO = reader.ReadInt32();
			PVRFilteringMode = reader.ReadInt32();
			PVRCulling = reader.ReadBoolean();
			reader.AlignStream(AlignType.Align4);

			PVRFilteringGaussRadiusDirect = reader.ReadInt32();
			PVRFilteringGaussRadiusIndirect = reader.ReadInt32();
			PVRFilteringGaussRadiusAO = reader.ReadInt32();
			PVRFilteringAtrousPositionSigmaDirect = reader.ReadSingle();
			PVRFilteringAtrousPositionSigmaIndirect = reader.ReadSingle();
			PVRFilteringAtrousPositionSigmaAO = reader.ReadSingle();
			ShowResolutionOverlay = reader.ReadBoolean();
			reader.AlignStream(AlignType.Align4);
		}

		public IEnumerable<Object> FetchDependencies(ISerializedFile file, bool isLog = false)
		{
			yield return LightmapParameters.FetchDependency(file, isLog, () => nameof(LightmapEditorSettings), "m_LightmapParameters");
		}

		public YAMLNode ExportYAML(IExportContainer container)
		{
			YAMLMappingNode node = new YAMLMappingNode();
			node.AddSerializedVersion(GetSerializedVersion(container.Version));
			node.Add("m_Resolution", Resolution);
			node.Add("m_BakeResolution", BakeResolution);
			node.Add("m_TextureWidth", TextureWidth);
			node.Add("m_TextureHeight", TextureHeight);
			node.Add("m_AO", AO);
			node.Add("m_AOMaxDistance", AOMaxDistance);
			node.Add("m_CompAOExponent", CompAOExponent);
			node.Add("m_CompAOExponentDirect", CompAOExponentDirect);
			node.Add("m_Padding", Padding);
			node.Add("m_LightmapParameters", LightmapParameters.ExportYAML(container));
			node.Add("m_LightmapsBakeMode", LightmapsBakeMode);
			node.Add("m_TextureCompression", TextureCompression);
			node.Add("m_FinalGather", FinalGather);
			node.Add("m_FinalGatherFiltering", FinalGatherFiltering);
			node.Add("m_FinalGatherRayCount", FinalGatherRayCount);
			node.Add("m_ReflectionCompression", ReflectionCompression);
			node.Add("m_MixedBakeMode", MixedBakeMode);
			node.Add("m_BakeBackend", BakeBackend);
			node.Add("m_PVRSampling", PVRSampling);
			node.Add("m_PVRDirectSampleCount", PVRDirectSampleCount);
			node.Add("m_PVRSampleCount", PVRSampleCount);
			node.Add("m_PVRBounces", PVRBounces);
			node.Add("m_PVRFilterTypeDirect", PVRFilterTypeDirect);
			node.Add("m_PVRFilterTypeIndirect", PVRFilterTypeIndirect);
			node.Add("m_PVRFilterTypeAO", PVRFilterTypeAO);
			node.Add("m_PVRFilteringMode", PVRFilteringMode);
			node.Add("m_PVRCulling", PVRCulling);
			node.Add("m_PVRFilteringGaussRadiusDirect", PVRFilteringGaussRadiusDirect);
			node.Add("m_PVRFilteringGaussRadiusIndirect", PVRFilteringGaussRadiusIndirect);
			node.Add("m_PVRFilteringGaussRadiusAO", PVRFilteringGaussRadiusAO);
			node.Add("m_PVRFilteringAtrousPositionSigmaDirect", PVRFilteringAtrousPositionSigmaDirect);
			node.Add("m_PVRFilteringAtrousPositionSigmaIndirect", PVRFilteringAtrousPositionSigmaIndirect);
			node.Add("m_PVRFilteringAtrousPositionSigmaAO", PVRFilteringAtrousPositionSigmaAO);
			node.Add("m_ShowResolutionOverlay", ShowResolutionOverlay);
			return node;
		}

		public float Resolution { get; set; }
		public float BakeResolution { get; set; }
		public int TextureWidth { get; set; }
		public int TextureHeight { get; set; }
		public bool AO { get; set; }
		public float AOMaxDistance { get; set; }
		public float CompAOExponent { get; set; }
		public float CompAOExponentDirect { get; set; }
		public int Padding { get; set; }
		public PPtr<LightmapParameters> LightmapParameters { get; set; }
		public int LightmapsBakeMode { get; set; }
		public bool TextureCompression { get; set; }
		public bool FinalGather { get; set; }
		public bool FinalGatherFiltering { get; set; }
		public int FinalGatherRayCount { get; set; }
		public int ReflectionCompression { get; set; }
		public int MixedBakeMode { get; set; }
		public int BakeBackend { get; set; }
		public int PVRSampling { get; set; }
		public int PVRDirectSampleCount { get; set; }
		public int PVRSampleCount { get; set; }
		public int PVRBounces { get; set; }
		public int PVRFilterTypeDirect { get; set; }
		public int PVRFilterTypeIndirect { get; set; }
		public int PVRFilterTypeAO { get; set; }
		public int PVRFilteringMode { get; set; }
		public bool PVRCulling { get; set; }
		public int PVRFilteringGaussRadiusDirect { get; set; }
		public int PVRFilteringGaussRadiusIndirect { get; set; }
		public int PVRFilteringGaussRadiusAO { get; set; }
		public float PVRFilteringAtrousPositionSigmaDirect { get; set; }
		public float PVRFilteringAtrousPositionSigmaIndirect { get; set; }
		public float PVRFilteringAtrousPositionSigmaAO { get; set; }
		public bool ShowResolutionOverlay { get; set; }
	}
}
