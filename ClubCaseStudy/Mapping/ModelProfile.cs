using AutoMapper;
using ClubCaseStudy.DTOs.Booking;
using ClubCaseStudy.DTOs.Facility;
using ClubCaseStudy.DTOs.Member;
using ClubCaseStudy.DTOs.MemberShip;
using ClubCaseStudy.DTOs.Payment;
using ClubCaseStudy.Models;

namespace ClubCaseStudy.Mapping
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {
            CreateMap<CreateMemberDTO, Memberr>();
            CreateMap<Memberr ,GetMemberDTO>();


            CreateMap<CreateMemberShipDTO, MemberShip>();
            CreateMap<MemberShip, GetMemberShipDTO>();

            CreateMap<CreateFacilityDTO, Facility>();
            CreateMap<Facility, GetFacilityDTO>();

            CreateMap<CreateBookingDTO, Booking>();
            CreateMap<Booking, GetBookingDTO>();

            CreateMap<CreatePaymentDTO, Payment>();
            CreateMap<Payment, GetPaymentDTO>();

        }
    }
}
